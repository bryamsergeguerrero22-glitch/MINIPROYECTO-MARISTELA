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
                        doc.Contains("HoraFin") ? doc["HoraFin"].ToString() : "00:00",//fecha,
                                                                                               // inicio, // Mostrará el texto tal cual: "13:00"
                                                                                               // fin,    // Mostrará el texto tal cual: "15:00"
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
    }
    
}
