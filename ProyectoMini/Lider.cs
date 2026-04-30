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
            // Reemplaza con tu cadena de conexión si es distinta
            var client = new MongoClient("mongodb://localhost:27017/");
            database = client.GetDatabase("Base_datos_Reunion"); // El nombre de tu BD
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
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "Usuario" },
                { "localField", "Participantes" },
                { "foreignField", "Nombres" },
                { "as", "info_participantes" }
            }),
            new BsonDocument("$match", new BsonDocument("$or", new BsonArray
            {
                new BsonDocument("Creador", usuarioLogueado),
                new BsonDocument("Participantes", usuarioLogueado)
            })),
            new BsonDocument("$project", new BsonDocument
            {
                { "ID", "$_id" },
                { "Fecha", "$fechaReunion" },      // Ahora es String
                { "HoraIni", "$horaInicio" },      // Ahora es String
                { "HoraFin", "$horaFin" },         // Ahora es String
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
                    // Ya no usamos ToUniversalTime porque ya no son objetos Date
                    string fecha = doc.Contains("Fecha") ? doc["Fecha"].ToString() : "N/A";
                    string inicio = doc.Contains("HoraIni") ? doc["HoraIni"].ToString() : "00:00";
                    string fin = doc.Contains("HoraFin") ? doc["HoraFin"].ToString() : "00:00";

                    // Procesar asistentes
                    string nombresAsistentes = "";
                    if (doc.Contains("Asistentes") && doc["Asistentes"].IsBsonArray)
                    {
                        var lista = doc["Asistentes"].AsBsonArray;
                        nombresAsistentes = string.Join(", ", lista.Select(x => x.ToString()));
                    }

                    dt.Rows.Add(
                        doc["ID"].ToString(),
                        fecha,
                        inicio, // Mostrará el texto tal cual: "13:00"
                        fin,    // Mostrará el texto tal cual: "15:00"
                        doc.Contains("Descripción") ? doc["Descripción"].ToString() : "N/A",
                        doc["Lugar"].ToString(),
                        doc.Contains("Org") ? doc["Org"].ToString() : "N/A",
                        nombresAsistentes
                    );
                }

                gunaDGVConsultarLider.DataSource = dt;

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron reuniones.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta Líder: " + ex.Message);
            }
        }

        private void gunabtnProgramarReunion_Click(object sender, EventArgs e)
        {
            ProgramarReunion PR = new ProgramarReunion(lblNombreUsuario.Text, lblRolUsuario.Text.Replace("Rol ", ""));
            PR.Show();
            this.Hide();
        }

        private void CargarConsultasDeUsuario()
        {
            try
            {
                // El nombre del usuario que inició sesión (el que está en tu Label)
                string nombreActual = lblNombreUsuario.Text;

                // FILTRO SIMPLE: Busca donde el nombre esté en el arreglo "participantes"
                var filtro = Builders<BsonDocument>.Filter.AnyEq("participantes", nombreActual);

                // Obtenemos los documentos
                var misReuniones = reunionesCollection.Find(filtro).ToList();

                // Llenar el DataGridView (dgvConsultas) de forma automática
               gunaDGVConsultarLider.DataSource = misReuniones.Select(r => new {
                    Fecha = r["fechaReunion"].ToUniversalTime().ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    Descripción = r["descripcionReunion"].AsString,
                    Ubicación = r["Lugar"].AsString,
                    Organizador = r.Contains("creador") ? r["creador"].AsString : "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message);
            }
        }

        private void guna2btnModificarReunion_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN CRÍTICA: Si no hay filas, no hacemos nada
            if (gunaDGVConsultarLider.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila completa en la tabla.");
                return;
            }

            try
            {
                // Extraemos el ID de la fila seleccionada
                // Asegúrate que "ID" coincida con el nombre de la columna en tu DataTable
                var valorId = gunaDGVConsultarLider.SelectedRows[0].Cells["ID"].Value;

                if (valorId != null)
                {
                    int idSeleccionado = int.Parse(valorId.ToString());

                    // Buscamos el documento en la BD
                    var filtro = Builders<BsonDocument>.Filter.Eq("_id", idSeleccionado);
                    var reunion = reunionesCollection.Find(filtro).FirstOrDefault();

                    if (reunion != null)
                    {
                        // PASO CLAVE: Usar el constructor que recibe el BsonDocument
                        ProgramarReunion frmEditar = new ProgramarReunion(lblNombreUsuario.Text, "Lider", reunion);
                        frmEditar.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar datos para editar: " + ex.Message);
            }
        }
    }
    
}
