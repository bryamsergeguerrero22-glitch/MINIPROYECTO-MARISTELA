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
        bool esEdicion = false;
        BsonDocument reunionAEditar;

        public ProgramarReunion(string nombreRecibido, string rolRecibido)
        {
            InitializeComponent();
            lblNombreUsuario.Text = nombreRecibido;
            lblRolUsuario.Text = "Rol " + rolRecibido;
            esEdicion = false;
        }

        // NUEVO CONSTRUCTOR PARA EDICIÓN
        public ProgramarReunion(string nombreRecibido, string rolRecibido, BsonDocument datos)
        {
            InitializeComponent();
            lblNombreUsuario.Text = nombreRecibido;
            lblRolUsuario.Text = "Rol " + rolRecibido;

            // Guardamos los datos que vienen del Líder
            this.reunionAEditar = datos;
            this.esEdicion = true;

            // Cambiamos el texto del botón de enviar
            gunabtnAgregarReunion.Text = "Actualizar Cambios";
        }

        private void gunabtnAgregarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                // --- 1. CAPTURA DE DATOS ---
                DateTime hoy = DateTime.Today;
                DateTime fechaBase = monthCalendar1.SelectionStart.Date;

                TimeSpan horaInicio = guna2DateTimePicker1.Value.TimeOfDay;
                TimeSpan horaFin = guna2DateTimePicker2.Value.TimeOfDay;

                // Convertimos a texto para la base de datos
                string fechaTexto = fechaBase.ToString("dd/MM/yyyy");
                string horaIniTexto = guna2DateTimePicker1.Value.ToString("HH:mm");
                string horaFinTexto = guna2DateTimePicker2.Value.ToString("HH:mm");

                // --- 2. VALIDACIONES ---

                // A. Validación de fecha pasada
                if (fechaBase < hoy)
                {
                    MessageBox.Show("No puedes programar reuniones en días pasados.", "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // B. RANGO PERMITIDO: 6 AM (6:00) a 6 PM (18:00)
                TimeSpan limiteInferior = new TimeSpan(6, 0, 0); // 06:00
                TimeSpan limiteSuperior = new TimeSpan(18, 0, 0); // 18:00

                if (horaInicio < limiteInferior || horaInicio > limiteSuperior ||
                    horaFin < limiteInferior || horaFin > limiteSuperior)
                {
                    MessageBox.Show("Las reuniones solo pueden programarse entre las 6:00 AM y las 6:00 PM.", "Horario no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // C. Validación lógica (Fin > Inicio)
                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("La hora de fin debe ser mayor a la hora de inicio.", "Error de Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
                {
                    MessageBox.Show("Por favor, escriba el lugar de la reunión.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // --- 3. GESTIÓN DE PARTICIPANTES ---
                List<string> seleccionados = new List<string>();
                foreach (var item in clbParticipantes.CheckedItems)
                {
                    seleccionados.Add(item.ToString());
                }

                if (seleccionados.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un participante.");
                    return;
                }

                // --- 4. DEFINIR EL ID ---
                int idReunion = esEdicion ? reunionAEditar["_id"].AsInt32 : GenerarSiguienteID();

                // --- 5. CREAR DOCUMENTO ---
                var nuevaReunion = new BsonDocument
        {
            { "_id", idReunion },
            { "fechaReunion", fechaTexto },
            { "horaInicio", horaIniTexto },
            { "horaFin", horaFinTexto },
            { "descripcionReunion", guna2TextBox1.Text.Trim() },
            { "Lugar", guna2TextBox2.Text.Trim() },
            { "Creador", lblNombreUsuario.Text.Trim() },
            { "Participantes", new BsonArray(seleccionados) }
        };

                // --- 6. GUARDADO Y REDIRECCIÓN ---
                if (esEdicion)
                {
                    var filtro = Builders<BsonDocument>.Filter.Eq("_id", idReunion);
                    reunionesCollection.ReplaceOne(filtro, nuevaReunion);
                    MessageBox.Show("La reunión se ha actualizado con éxito, por favor realice la consulta.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reunionesCollection.InsertOne(nuevaReunion);
                    MessageBox.Show("Se ha registrado la reunión con éxito por favor realice la consulta.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // EN AMBOS CASOS: Mandar al Form de Líder y cerrar este
                // Nota: Asegúrate que lblRolUsuario tenga el texto correcto para el constructor
                string rolLimpio = lblRolUsuario.Text.Replace("Rol ", "").Trim();
                Lider liderForm = new Lider(lblNombreUsuario.Text.Trim(), rolLimpio);
                liderForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la reunión: " + ex.Message);
            }

        }







        private void guna2btnConsultarReunion_Click(object sender, EventArgs e)
        {
            Lider liderForm = new Lider(lblNombreUsuario.Text, lblRolUsuario.Text.Replace("Rol ", ""));
            liderForm.Show();
            this.Hide();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿ desea salir ?", "mensaje importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ProgramarReunion_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Conexión y carga inicial
                var client = new MongoClient("mongodb://localhost:27017/");
                database = client.GetDatabase("Base_datos_Reunion");

                UsuarioCollection = database.GetCollection<BsonDocument>("Usuario");
                reunionesCollection = database.GetCollection<BsonDocument>("Reunion");

                CargarParticipantes();
                clbParticipantes.CheckOnClick = true;

                // --- VALIDACIÓN PARA EDICIÓN ---
                if (esEdicion && reunionAEditar != null)
                {
                    // A. Llenar los campos de texto
                    guna2TextBox1.Text = reunionAEditar.Contains("descripcionReunion") ? reunionAEditar["descripcionReunion"].ToString() : "";
                    guna2TextBox2.Text = reunionAEditar.Contains("Lugar") ? reunionAEditar["Lugar"].ToString() : "";

                    // B. Configurar fechas y horas (CONVERSIÓN DE STRING A DATETIME)
                    // Leemos los strings que guardamos: "dd/MM/yyyy" y "HH:mm"

                    if (reunionAEditar.Contains("fechaReunion"))
                    {
                        string fechaStr = reunionAEditar["fechaReunion"].AsString;
                        DateTime fechaCargada = DateTime.ParseExact(fechaStr, "dd/MM/yyyy", null);
                        monthCalendar1.SetDate(fechaCargada);
                    }

                    if (reunionAEditar.Contains("horaInicio"))
                    {
                        string horaIniStr = reunionAEditar["horaInicio"].AsString;
                        // Usamos la fecha de hoy solo como base para que el control muestre la hora
                        guna2DateTimePicker1.Value = DateTime.ParseExact(horaIniStr, "HH:mm", null);
                    }

                    if (reunionAEditar.Contains("horaFin"))
                    {
                        string horaFinStr = reunionAEditar["horaFin"].AsString;
                        guna2DateTimePicker2.Value = DateTime.ParseExact(horaFinStr, "HH:mm", null);
                    }

                    // C. Marcar los participantes (Mantenemos tu lógica de validación de Array o String)
                    if (reunionAEditar.Contains("Participantes"))
                    {
                        var valorParticipantes = reunionAEditar["Participantes"];

                        if (valorParticipantes.IsBsonArray)
                        {
                            var listaParticipantesBD = valorParticipantes.AsBsonArray;
                            for (int i = 0; i < clbParticipantes.Items.Count; i++)
                            {
                                if (listaParticipantesBD.Contains(clbParticipantes.Items[i].ToString()))
                                {
                                    clbParticipantes.SetItemChecked(i, true);
                                }
                            }
                        }
                        else if (valorParticipantes.IsString)
                        {
                            string nombreUnico = valorParticipantes.AsString;
                            for (int i = 0; i < clbParticipantes.Items.Count; i++)
                            {
                                if (clbParticipantes.Items[i].ToString() == nombreUnico)
                                {
                                    clbParticipantes.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos para edición: " + ex.Message);
            }
        }

       

        private void CargarParticipantes()
        {
            try
            {
                var usuarios = UsuarioCollection.Find(new BsonDocument()).ToList();
                clbParticipantes.Items.Clear();

                foreach (var doc in usuarios)
                {
                    // Usamos el campo "Nombres" como indicaste en tu último mensaje
                    if (doc.Contains("Nombres"))
                    {
                        string nombre = doc.GetValue("Nombres").AsString;
                        clbParticipantes.Items.Add(nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
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

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

