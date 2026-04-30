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
    public partial class Investigador : Form
    {
        IMongoDatabase database;
        IMongoCollection<BsonDocument> usuariosCollection;
        IMongoCollection<BsonDocument> reunionesCollection;
        public Investigador(string nombreRecibido, string rolRecibido)
        {
            InitializeComponent();
            lblNombreUsuario.Text = nombreRecibido;
            lblRolUsuario.Text = "Rol " + rolRecibido;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Mensaje Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Investigador_Load(object sender, EventArgs e)
        {
            // Reemplaza con tu cadena de conexión si es distinta
            var client = new MongoClient("mongodb://localhost:27017/");
            database = client.GetDatabase("Base_datos_Reunion"); // El nombre de tu BD
            usuariosCollection = database.GetCollection<BsonDocument>("Usuario");
            reunionesCollection = database.GetCollection<BsonDocument>("Reunion");

        }

        private void gunabtnConsultarReunion_Click(object sender, EventArgs e)
        {
            var filtro = Builders<BsonDocument>.Filter.AnyEq("Participantes", lblNombreUsuario.Text.Trim());
            var resultados = reunionesCollection.Find(filtro).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Hora de inicio");
            dt.Columns.Add("Hora de finalización"); // <-- NUEVA COLUMNA
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Lugar");
            dt.Columns.Add("Organizador");

            foreach (var doc in resultados)
            {
                DateTime inicio = doc["fechaReunion"].ToUniversalTime();
                DateTime fin = doc["fechaHoraFin"].ToUniversalTime();
                dt.Rows.Add(
                    doc["_id"].ToString(),
                    doc["fechaReunion"].ToLocalTime().ToString("dd/MM/yyyy"),
                    doc["fechaReunion"].ToLocalTime().ToString("HH:mm"), // <-- MOSTRAR HORA INICIO
                    doc["fechaHoraFin"].ToLocalTime().ToString("HH:mm"), // <-- MOSTRAR HORA FIN
                    doc["descripcionReunion"].ToString(),
                    doc["Lugar"].ToString(),
                    doc.Contains("Creador") ? doc["Creador"].ToString() : "Desconocido" // <-- MAPEO DEL CAMPO
                );
            }
            guna2DataGridView1.DataSource = dt;

        }
  

        


        private void btnborrar_Click(object sender, EventArgs e)
        {
        
            try
            {
                // 1. Validar que seleccionó algo
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {
                    // 2. Obtener el ID oculto de la fila seleccionada
                    int idABorrar = int.Parse(guna2DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());

                    // 3. Confirmación
                    DialogResult confirm = MessageBox.Show("¿Deseas eliminar esta reunión definitivamente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        // 4. Filtro por el ID de MongoDB
                        var filtro = Builders<BsonDocument>.Filter.Eq("_id", idABorrar);
                        reunionesCollection.DeleteOne(filtro);

                        // 5. Borrar de la colección
                        reunionesCollection.DeleteOne(filtro);

                        MessageBox.Show("Reunión eliminada con éxito.");

                        // 6. Refrescar el DataGrid automáticamente para que desaparezca
                        gunabtnConsultarReunion_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una reunión de la lista primero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar: " + ex.Message);
            }
        }
    }
    
}