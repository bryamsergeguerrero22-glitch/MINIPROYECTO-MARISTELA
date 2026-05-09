using Guna.UI2.WinForms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMini
{
    public partial class ProgramarReunion : Form
    {
        IMongoDatabase database;
        IMongoCollection<BsonDocument> UsuarioCollection;
        IMongoCollection<BsonDocument> reunionesCollection;
        IMongoCollection<BsonDocument> SemilleroCollection;
        bool esEdicion = false;
        bool cargandoDatosIniciales = false; // Nueva bandera
        BsonDocument reunionAEditar;

        public ProgramarReunion(string nombreRecibido, string rolRecibido)
        {
            InitializeComponent();
            ConfiguracionInicial(nombreRecibido, rolRecibido);
            esEdicion = false;
        }

        // NUEVO CONSTRUCTOR PARA EDICIÓN
        public ProgramarReunion(string nombreRecibido, string rolRecibido, BsonDocument datos)
        {
            InitializeComponent();
            ConfiguracionInicial(nombreRecibido, rolRecibido);
            // Guardamos los datos que vienen del Líder
            this.reunionAEditar = datos;
            this.esEdicion = true;
            // Cambiamos el texto del botón de enviar
            gunabtnAgregarReunion.Text = "Actualizar Cambios";
        }

        private void ConfiguracionInicial(string nombre, string rol)
        {
            lblNombreUsuario.Text = nombre;
            lblRolUsuario.Text = "Rol " + rol;

            // Conexión a MongoDB
            var client = new MongoClient("mongodb://localhost:27017/");
            database = client.GetDatabase("Base_datos_Reunion");
            UsuarioCollection = database.GetCollection<BsonDocument>("Usuario");
            reunionesCollection = database.GetCollection<BsonDocument>("Reunion");
            SemilleroCollection = database.GetCollection<BsonDocument>("Semillero");

            clbParticipantes.CheckOnClick = true;
            // monthCalendar1.MinDate = DateTime.Today;
        }

        private void gunabtnAgregarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. CAPTURA DE DATOS NORMALIZADOS
                DateTime hoy = DateTime.Today;
                DateTime fechaBase = monthCalendar1.SelectionStart.Date;

                // Usamos TimeOfDay para evitar errores de comparación de fechas internas
                TimeSpan horaInicio = guna2DateTimePicker1.Value.TimeOfDay;
                TimeSpan horaFin = guna2DateTimePicker2.Value.TimeOfDay;

                // Convertimos el lugar a minúsculas para evitar duplicados como "SENA" y "sena"
                string lugarNuevo = gunatxtLugar.Text.Trim().ToLower();

                // 2. VALIDACIONES LÓGICAS
                if (fechaBase < hoy) { MessageBox.Show("No puedes programar en días pasados.", "Error"); return; }
                if (fechaBase.DayOfWeek == DayOfWeek.Sunday) { MessageBox.Show("No se permiten domingos.", "Error"); return; }
                if (horaFin <= horaInicio) { MessageBox.Show("La hora de fin debe ser mayor a la de inicio.", "Error de secuencia"); return; }
                if (string.IsNullOrEmpty(lugarNuevo)) { MessageBox.Show("Debe ingresar un lugar.", "Campo vacío"); return; }

                List<string> seleccionados = clbParticipantes.CheckedItems.Cast<object>().Select(x => x.ToString()).ToList();
                if (seleccionados.Count == 0) { MessageBox.Show("Seleccione al menos un participante."); return; }

                int idActual = esEdicion ? reunionAEditar["_id"].AsInt32 : GenerarSiguienteID();

                // 3. VALIDACIÓN DE CRUCE DE LUGAR (Búsqueda inteligente con Regex)
                var filtroLugar = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("fechaReunion", fechaBase.ToString("dd/MM/yyyy")),
                    Builders<BsonDocument>.Filter.Regex("Lugar", new BsonRegularExpression("^" + lugarNuevo + "$", "i"))
                );

                var crucesLugar = reunionesCollection.Find(filtroLugar).ToList();
                foreach (var cl in crucesLugar)
                {
                    if (cl["_id"].AsInt32 == idActual) continue;

                    TimeSpan exIni = TimeSpan.Parse(cl["horaInicio"].AsString);
                    TimeSpan exFin = TimeSpan.Parse(cl["horaFin"].AsString);

                    if (horaInicio < exFin && horaFin > exIni)
                    {
                        MessageBox.Show($"El lugar '{cl["Lugar"]}' ya está ocupado en ese horario.", "Cruce de Lugar");
                        return;
                    }
                }

                // 4. CREACIÓN DEL DOCUMENTO
                var docReunion = new BsonDocument {
                    { "_id", idActual },
                     { "Semillero", gunacmbSemilleros.SelectedItem?.ToString() ?? "" },
                    { "fechaReunion", fechaBase.ToString("dd/MM/yyyy") },
                    { "horaInicio", guna2DateTimePicker1.Value.ToString("HH:mm") },
                    { "horaFin", guna2DateTimePicker2.Value.ToString("HH:mm") },
                    { "descripcionReunion", guna2TextBox1.Text.Trim() },
                    { "Lugar", lugarNuevo },
                    { "Creador", lblNombreUsuario.Text },
                    { "Participantes", new BsonArray(seleccionados) }
                };

                // 5. GUARDADO EN MONGODB
                if (esEdicion)
                    reunionesCollection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("_id", idActual), docReunion);
                else
                    reunionesCollection.InsertOne(docReunion);

                MessageBox.Show("Reunión guardada exitosamente.", "Éxito");

                // 6. NAVEGACIÓN AL FORMULARIO LIDER
                string soloRol = lblRolUsuario.Text.Replace("Rol ", "");
                Lider liderForm = new Lider(lblNombreUsuario.Text, soloRol);
                liderForm.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }



        }



        private void guna2btnConsultarReunion_Click(object sender, EventArgs e)
        {
            Lider liderForm = new Lider(lblNombreUsuario.Text, lblRolUsuario.Text.Replace("Rol ", ""));
            liderForm.Show();
            this.Hide();
        }

        

        private void ProgramarReunion_Load(object sender, EventArgs e)
        {
            cargandoDatosIniciales = true; // Bloqueamos disparos de eventos

            CargarSemilleros();

            if (esEdicion && reunionAEditar != null)
            {
                CargarDatosEdicion();
            }

            cargandoDatosIniciales = false; // Liberamos
        }

        private void CargarSemilleros()
        {
            try
            {
                var semilleros = SemilleroCollection.Find(new BsonDocument()).ToList();
                gunacmbSemilleros.Items.Clear();
                foreach (var s in semilleros)
                {
                    gunacmbSemilleros.Items.Add(s["Nombre_Semillero"].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar semilleros: " + ex.Message); }
        }



        private void CargarDatosEdicion()
        {
            try
            {
                DateTime fecha = DateTime.ParseExact(reunionAEditar["fechaReunion"].AsString, "dd/MM/yyyy", null);
                monthCalendar1.SetDate(fecha);
                gunatxtLugar.Text = reunionAEditar["Lugar"].AsString;
                guna2TextBox1.Text = reunionAEditar["descripcionReunion"].AsString;
                guna2DateTimePicker1.Value = DateTime.Today.Add(TimeSpan.Parse(reunionAEditar["horaInicio"].AsString));
                guna2DateTimePicker2.Value = DateTime.Today.Add(TimeSpan.Parse(reunionAEditar["horaFin"].AsString));

                // OBTENER PARTICIPANTES GUARDADOS
                List<string> participantesGuardados = new List<string>();
                if (reunionAEditar.Contains("Participantes"))
                {
                    participantesGuardados = reunionAEditar["Participantes"].AsBsonArray
                                             .Select(p => p.ToString()).ToList();
                }

                // BUSCAR EL SEMILLERO A PARTIR DEL PRIMER PARTICIPANTE
                string semilleroEncontrado = "";
                if (participantesGuardados.Count > 0)
                {
                    var filtroUsuario = Builders<BsonDocument>.Filter.Eq("Nombres", participantesGuardados[0]);
                    var usuarioDoc = UsuarioCollection.Find(filtroUsuario).FirstOrDefault();
                    if (usuarioDoc != null && usuarioDoc.Contains("Nombre_Semillero"))
                        semilleroEncontrado = usuarioDoc["Nombre_Semillero"].ToString();
                }

                // SELECCIONAR EL SEMILLERO EN EL COMBOBOX
                if (!string.IsNullOrEmpty(semilleroEncontrado))
                {
                    int idx = gunacmbSemilleros.Items.IndexOf(semilleroEncontrado);
                    if (idx >= 0)
                        gunacmbSemilleros.SelectedIndex = idx;
                }

                // LLENAR LA LISTA CON TODOS LOS USUARIOS DEL SEMILLERO
                ActualizarListaParticipantes();

                // MARCAR LOS QUE YA ESTABAN EN LA REUNIÓN
                for (int i = 0; i < clbParticipantes.Items.Count; i++)
                {
                    if (participantesGuardados.Contains(clbParticipantes.Items[i].ToString()))
                        clbParticipantes.SetItemChecked(i, true);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar edición: " + ex.Message); }
        }

        private int GenerarSiguienteID()
        {
            try
            {
                // Buscamos el documento con el _id más alto
                var ultimoDoc = reunionesCollection.Find(new BsonDocument())
                                .Sort(Builders<BsonDocument>.Sort.Descending("_id"))
                                .Limit(1)
                                .FirstOrDefault();

                if (ultimoDoc != null)
                {
                    // Tomamos el valor actual y le sumamos 1
                    return ultimoDoc["_id"].AsInt32 + 1;
                }
                return 1; // Si no hay documentos, empezamos en 1
            }
            catch
            {
                return 1;
            }
        }

       

        private void btnsalir_Click_1(object sender, EventArgs e) // Boton salir
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Mensaje Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Form1 Inicio = new Form1();
                Inicio.Show();
                this.Close();
            }
        }

        

        private void gunacmbSemilleros_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SI ESTAMOS CARGANDO DATOS DE EDICIÓN, NO HACEMOS NADA AQUÍ
            if (cargandoDatosIniciales) return;

            try
            {
                // --- 1. CAPTURA DE DATOS (Para que ya no salgan en rojo) ---
                // Obtenemos los valores actuales de los controles de tu formulario
                string fechaSeleccionada = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                TimeSpan horaInicio = guna2DateTimePicker1.Value.TimeOfDay;
                TimeSpan horaFin = guna2DateTimePicker2.Value.TimeOfDay;

                // 2. Obtener el semillero seleccionado
                if (gunacmbSemilleros.SelectedItem == null) return;
                string semillero = gunacmbSemilleros.SelectedItem.ToString();

                // 3. Consultar MongoDB (Filtro por Semillero y Rol)
                var filtro = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("Nombre_Semillero", semillero));

                var listaUsuarios = UsuarioCollection.Find(filtro).ToList();

                // 4. Limpiar el CheckedListBox
                clbParticipantes.Items.Clear();

                // 5. Llenar con validación de disponibilidad
                foreach (var usuario in listaUsuarios)
                {
                    string nombre = usuario["Nombres"].ToString();

                    // Ahora las variables ya existen y se pasan correctamente
                    if (EstaDisponible(nombre, fechaSeleccionada, horaInicio, horaFin))
                    {
                        clbParticipantes.Items.Add(nombre);
                    }
                }

                if (listaUsuarios.Count == 0)
                {
                    MessageBox.Show("No hay investigadores registrados en este semillero.", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar participantes: " + ex.Message);
            }
        }

        private bool EstaDisponible(string nombreParticipante, string fecha, TimeSpan inicioNuevo, TimeSpan finNuevo)
        {
            var filtroFecha = Builders<BsonDocument>.Filter.Eq("fechaReunion", fecha);
            var reunionesDelDia = reunionesCollection.Find(filtroFecha).ToList();

            foreach (var reunion in reunionesDelDia)
            {
                // Si es edición, ignoramos la reunión que estamos editando actualmente
                if (esEdicion && reunionAEditar != null && reunion["_id"].AsInt32 == reunionAEditar["_id"].AsInt32)
                    continue;

                var participantes = reunion["Participantes"].AsBsonArray.Select(p => p.ToString()).ToList();

                if (participantes.Contains(nombreParticipante))
                {
                    TimeSpan exInicio = TimeSpan.Parse(reunion["horaInicio"].AsString);
                    TimeSpan exFin = TimeSpan.Parse(reunion["horaFin"].AsString);

                    if (inicioNuevo < exFin && finNuevo > exInicio) return false;
                }
            }
            return true;
        }


        // Método para refrescar la lista de participantes según disponibilidad actual
        private void ActualizarListaParticipantes()
        {
            if (gunacmbSemilleros.SelectedItem == null) return;

            try
            {
                string semillero = gunacmbSemilleros.SelectedItem.ToString();
                string fecha = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                TimeSpan inicio = guna2DateTimePicker1.Value.TimeOfDay;
                TimeSpan fin = guna2DateTimePicker2.Value.TimeOfDay;

                var filtro = Builders<BsonDocument>.Filter.Eq("Nombre_Semillero", semillero);

                var investigadores = UsuarioCollection.Find(filtro).ToList();
                clbParticipantes.Items.Clear();

                foreach (var inv in investigadores)
                {
                    // Importante: Usamos "Nombres" para ser consistentes con tu DB
                    string nombre = inv.Contains("Nombres") ? inv["Nombres"].ToString() : inv["Nombre"].ToString();

                    if (EstaDisponible(nombre, fecha, inicio, fin))
                    {
                        clbParticipantes.Items.Add(nombre);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error dinámico: " + ex.Message); }
        }

     

        private void guna2DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            // Definimos el rango permitido
            TimeSpan limiteManana = new TimeSpan(6, 0, 0);
            TimeSpan limiteTarde = new TimeSpan(18, 0, 0);
            TimeSpan actual = guna2DateTimePicker1.Value.TimeOfDay;

            if (actual < limiteManana || actual > limiteTarde)
            {
                MessageBox.Show("El horario permitido es de 6:00 AM a 6:00 PM.", "Aviso");

                // Forzamos el reinicio a las 6:00 AM
                guna2DateTimePicker1.Value = DateTime.Today.AddHours(6);
            }
            ActualizarListaParticipantes();
        }

        private void guna2DateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            // IMPORTANTE: Comparamos .TimeOfDay en ambos
            TimeSpan inicio = guna2DateTimePicker1.Value.TimeOfDay;
            TimeSpan fin = guna2DateTimePicker2.Value.TimeOfDay;

            TimeSpan limiteManana = new TimeSpan(6, 0, 0);
            TimeSpan limiteTarde = new TimeSpan(18, 0, 0);

            if (fin < limiteManana || fin > limiteTarde)
            {
                MessageBox.Show("La hora de fin debe estar entre las 06:00 y 18:00.", "Horario Inválido");
                guna2DateTimePicker2.Value = DateTime.Today.AddHours(18); // Lo manda a las 6 PM
                return;
            }

            // Aquí es donde te salía el error: comparamos solo las horas del día
            if (fin <= inicio)
            {
                MessageBox.Show("La hora de finalización debe ser mayor a la de inicio.", "Error de secuencia");
                guna2DateTimePicker2.Value = DateTime.Today.AddHours(18); // Lo limpia a las 6 PM
            }

            ActualizarListaParticipantes();
        }

        // 1. Agrega esta variable justo arriba del método (fuera de él)
        bool procesandoFecha = false;
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 1. Evitamos que el código se ejecute a sí mismo al resetear la fecha
            if (procesandoFecha) return;

            // Capturamos la fecha seleccionada
            DateTime fechaSeleccionada = e.Start.Date;

            // --- VALIDACIÓN 1: FECHAS PASADAS ---
            if (fechaSeleccionada < DateTime.Today)
            {
                procesandoFecha = true;
                MessageBox.Show("No puedes programar reuniones en fechas pasadas. Por favor, selecciona una fecha a partir de hoy.",
                                "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LimpiarYResetearCalendario();
                procesandoFecha = false;
                return;
            }

            // --- VALIDACIÓN 2: DOMINGOS ---
            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Sunday)
            {
                procesandoFecha = true;
                MessageBox.Show("No se permiten programar reuniones los días domingo. Por favor, seleccione un día laboral.",
                                "Día no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LimpiarYResetearCalendario();
                procesandoFecha = false;
                return;
            }

            // Si pasa ambas validaciones, actualizamos la lista de participantes
            ActualizarListaParticipantes();
        }

        // Método auxiliar para no repetir código de limpieza
        private void LimpiarYResetearCalendario()
        {
            monthCalendar1.SetDate(DateTime.Today); // Regresa a hoy
            clbParticipantes.Items.Clear();         // Limpia la lista de nombres
        }
    }
}

