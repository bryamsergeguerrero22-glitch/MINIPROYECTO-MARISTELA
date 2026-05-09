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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProyectoMini
{
    public partial class Lider : Form
    {
        IMongoDatabase database;
        IMongoCollection<BsonDocument> usuariosCollection;
        IMongoCollection<BsonDocument> reunionesCollection;
        public Lider(string nombreRecibido, string rolRecibido)
        {
            InitializeComponent();
            lblNombreUsuario.Text = nombreRecibido;
            lblRolUsuario.Text = "Rol " + rolRecibido;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿ desea salir ?", "mensaje importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Lider_Load(object sender, EventArgs e)
        {
           // Conexion a la base de datos y a la coleccion
            var client = new MongoClient("mongodb://localhost:27017/");
            database = client.GetDatabase("Base_datos_Reunion");
            usuariosCollection = database.GetCollection<BsonDocument>("Usuario");
            reunionesCollection = database.GetCollection<BsonDocument>("Reunion");
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioLogueado = lblNombreUsuario.Text.Trim();
                var collection = database.GetCollection<BsonDocument>("Reunion");

                // 1. Pipeline de agregación ajustado a los nuevos campos de texto
                var pipeline = new[]
                {
                new BsonDocument("$lookup", new BsonDocument //Une coleccion
                {
                { "from", "Usuario" },
                { "localField", "Participantes" },
                { "foreignField", "Nombres" },
                { "as", "info_participantes" }
                }),
            new BsonDocument("$match", new BsonDocument("$or", new BsonArray // Realiza filtro donde aparezca como creador o lider
            {
                new BsonDocument("Creador", usuarioLogueado),
                new BsonDocument("Participantes", usuarioLogueado)
            })),
            new BsonDocument("$project", new BsonDocument // organiza los datos para la vista
            {
                { "ID", "$_id" },
                { "Fecha", "$fechaReunion" },      
                { "HoraIni", "$horaInicio" },      
                { "HoraFin", "$horaFin" },         
                { "Descripción", "$descripcionReunion" },
                { "Lugar", "$Lugar" },
                { "Org", "$Creador" },
                { "Asistentes", "$info_participantes.Nombres" }
            })
        };

                var resultados = collection.Aggregate<BsonDocument>(pipeline).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Inicio");
                dt.Columns.Add("Fin");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Lugar");
                dt.Columns.Add("Organizador");
                dt.Columns.Add("Participantes");

                // 3. Recorremos los resultados leyendo TEXTO puro
                foreach (var doc in resultados)
                {
                    // Procesar asistentes
                    string nombresAsistentes = "";
                    if (doc.Contains("Asistentes") && doc["Asistentes"].IsBsonArray)
                    {
                        var lista = doc["Asistentes"].AsBsonArray;
                        nombresAsistentes = string.Join(", ", lista.Select(x => x.ToString()));
                    }

                    dt.Rows.Add(
                        doc["ID"].ToString(),
                        doc.Contains("Fecha") ? doc["Fecha"].ToString() : "N/A",
                        doc.Contains("HoraIni") ? doc["HoraIni"].ToString() : "00:00",
                        doc.Contains("HoraFin") ? doc["HoraFin"].ToString() : "00:00",
                        doc.Contains("Descripción") ? doc["Descripción"].ToString() : "N/A",
                        doc["Lugar"].ToString(),
                        doc.Contains("Org") ? doc["Org"].ToString() : "N/A",
                        nombresAsistentes
                    );
                }

                gunaDGVConsultarLider.DataSource = dt;
                gunaDGVConsultarLider.ClearSelection();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron reuniones.", "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta Líder: " + ex.Message, "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gunabtnProgramarReunion_Click(object sender, EventArgs e)
        {
            ProgramarReunion PR = new ProgramarReunion(lblNombreUsuario.Text, lblRolUsuario.Text.Replace("Rol ", ""));
            PR.Show();
            this.Hide();
        }

        private void guna2btnModificarReunion_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN CRÍTICA: Si no hay filas, no hacemos nada
            if (gunaDGVConsultarLider.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila completa en la tabla.", "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 2. Si pasó la validación, obtenemos el ID con seguridad
                var fila = gunaDGVConsultarLider.SelectedRows[0];
                var valorId = fila.Cells["ID"].Value;

                if (valorId != null)
                {
                    int idSeleccionado = int.Parse(valorId.ToString());

                    var filtro = Builders<BsonDocument>.Filter.Eq("_id", idSeleccionado);
                    var reunion = reunionesCollection.Find(filtro).FirstOrDefault();

                    if (reunion != null)
                    {
                        ProgramarReunion frmEditar = new ProgramarReunion(lblNombreUsuario.Text, "Lider", reunion);
                        frmEditar.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar datos para editar: " + ex.Message, "Mensaje Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private void btnsalir_Click_2(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Mensaje Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Form1 Inicio = new Form1();
                Inicio.Show();
                this.Close();
            }
        }

        private void gunabtnConsultaFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                //Se obtiene el criterio y valor de la busqueda
                string criterio = cmbFiltro.SelectedItem?.ToString();
                string valorBusqueda = txtValorBusqueda.Text.Trim();

                var filterBuilder = Builders<BsonDocument>.Filter;
                FilterDefinition<BsonDocument> filtroFinal = filterBuilder.Empty;

                //Definir el filtro según la seleccion escogida

                switch (criterio)
                {
                    case "ID":
                        // Validamos que el usuario haya escrito un número
                        if (int.TryParse(valorBusqueda, out int identero))
                        {
                            filtroFinal = filterBuilder.Eq("_id", identero);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese un ID numérico válido (ejemplo: 1).", "Dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Detiene la ejecución para que el usuario corrija
                        }
                        break;

                    case "Mes":
                        // Validamos que el mes tenga sentido (2 dígitos y entre 01 y 12)
                        if (valorBusqueda.Length == 2 && int.TryParse(valorBusqueda, out int mes) && mes >= 1 && mes <= 12)
                        {
                            filtroFinal = filterBuilder.Regex("fechaReunion", new BsonRegularExpression($"/{valorBusqueda}/"));
                        }
                        else
                        {
                            MessageBox.Show("Ingrese el mes en formato de dos dígitos (01 a 12). Ejemplo: 05 para Mayo.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        break;

                    case "Fecha":
                        // Validamos que el campo no esté vacío y tenga el formato básico de fecha
                        if (!string.IsNullOrEmpty(valorBusqueda) && valorBusqueda.Contains("/"))
                        {
                            filtroFinal = filterBuilder.Eq("fechaReunion", valorBusqueda);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una fecha válida con el formato dd/mm/aaaa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;

                    case "Organizador":
                        if (!string.IsNullOrWhiteSpace(valorBusqueda))
                        {
                            filtroFinal = filterBuilder.Regex("Creador", new BsonRegularExpression(valorBusqueda, "i"));
                        }
                        else
                        {
                            MessageBox.Show("Por favor, escriba el nombre del organizador a buscar.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Por favor seleccione un criterio de búsqueda.");
                        return;
                }

                var resultados = reunionesCollection.Find(filtroFinal).ToList();
                ActualizarTabla(resultados);
                // 2. JUSTO AQUÍ EVALUAMOS LA VARIABLE 'resultados'
                if (resultados.Count > 0)
                {
                    // Si la lista tiene al menos 1 elemento, llenamos la tabla
                    ActualizarTabla(resultados);
                }
                else
                {
                    // Si la lista está vacía (0), limpiamos el grid y avisamos
                    gunaDGVConsultarLider.DataSource = null;
                    txtValorBusqueda.Clear();
                    txtValorBusqueda.Focus();
                    MessageBox.Show("No se encontró ninguna información relacionada con su búsqueda.",
                                    "Sin Resultados",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta, por favor verifique el campo que ha seleccionado y lo que desea consultar." + ex.Message);
            }
        }

        private void ActualizarTabla(List<BsonDocument> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Hora de inicio");
            dt.Columns.Add("Hora de finalización");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Lugar");
            dt.Columns.Add("Organizador");
            dt.Columns.Add("Estado");

            DateTime ahora = DateTime.Now;

            foreach (var doc in lista)
            {
                string estado = "Desconocido";
                try
                {
                    DateTime inicio = DateTime.Parse(doc["fechaReunion"].ToString() + " " + doc["horaInicio"].ToString());
                    DateTime fin = DateTime.Parse(doc["fechaReunion"].ToString() + " " + doc["horaInicio"].ToString());

                    if (ahora < inicio) estado = "Programada";
                    else if (ahora >= inicio && ahora <= fin) estado = "Iniciada";
                    else estado = "Finalizada";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la consulta" + ex.Message);
                }

                dt.Rows.Add(
                    doc["_id"].ToString(),
                    doc.Contains("fechaReunion") ? doc["fechaReunion"].ToString() : "N/A",
                    doc.Contains("horaInicio") ? doc["horaInicio"].ToString() : "00:00",
                    doc.Contains("horaFin") ? doc["horaFin"].ToString() : "00:00",
                    doc.Contains("descripcionReunion") ? doc["descripcionReunion"].ToString() : "Sin descripción",
                    doc.Contains("Lugar") ? doc["Lugar"].ToString() : "N/A",
                    doc.Contains("Creador") ? doc["Creador"].ToString() : "Desconocido",
                    estado);
            }

            gunaDGVConsultarLider.DataSource = dt;
        }
    }
    
}
