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
        IMongoDatabase database;// variable que reprensenta la base de datos Mongodb
        IMongoCollection<BsonDocument> usuariosCollection;// variable que representa la coleccion usuarios
        IMongoCollection<BsonDocument> reunionesCollection;// variable que representa la coleccion reuniones
        public Investigador(string nombreRecibido, string rolRecibido) //Son parámetros del constructor que reciben datos al crear el formulario y se usan para mostrarlos en pantalla.
        {
            InitializeComponent(); // Construye visulamente el formulario
            lblNombreUsuario.Text = nombreRecibido; //Guarda el nombre recibido
            lblRolUsuario.Text = "Rol " + rolRecibido; // Guarda el rol recibido
        }

        private void Investigador_Load(object sender, EventArgs e)
        {
            // Conexion a la base de datos y a las colecciones
            var client = new MongoClient("mongodb://localhost:27017/"); // Nombre del servidor 
            database = client.GetDatabase("Base_datos_Reunion"); // Nombre de la base de datos
            usuariosCollection = database.GetCollection<BsonDocument>("Usuario"); // Colleciones de la base de datos usuarios y reunion con sus documentos
            reunionesCollection = database.GetCollection<BsonDocument>("Reunion");

        }

        private void gunabtnConsultarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                var filtro = Builders<BsonDocument>.Filter.AnyEq("Participantes", lblNombreUsuario.Text.Trim());
                var resultados = reunionesCollection.Find(filtro).ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Hora de inicio");
                dt.Columns.Add("Hora de finalización");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Lugar");
                dt.Columns.Add("Organizador");

                foreach (var doc in resultados)
                {
                    // LEER COMO STRING (Porque ya no son objetos Date de Mongo)
                    //string fecha = doc.Contains("fechaReunion") ? doc["fechaReunion"].ToString() : "N/A";
                    //string inicio = doc.Contains("horaInicio") ? doc["horaInicio"].ToString() : "00:00";
                    //string fin = doc.Contains("horaFin") ? doc["horaFin"].ToString() : "00:00";

                    dt.Rows.Add(
                        doc["_id"].ToString(),
                        doc.Contains("fechaReunion") ? doc["fechaReunion"].ToString() : "N/A", // Operador ternario es como un if-else pero mas corto y en una sola linea
                        doc.Contains("horaInicio") ? doc["horaInicio"].ToString() : "00:00",
                        doc.Contains("horaFin") ? doc["horaFin"].ToString() : "00:00",
                        doc.Contains("descripcionReunion") ? doc["descripcionReunion"].ToString() : "Sin descripción",
                        doc.Contains("Lugar") ? doc["Lugar"].ToString() : "N/A",
                        doc.Contains("Creador") ? doc["Creador"].ToString() : "Desconocido"
                    );
                }
                guna2DataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message, "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

 
        private void btnsalir_Click_1(object sender, EventArgs e)
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