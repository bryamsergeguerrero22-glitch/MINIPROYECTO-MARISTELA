using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace ProyectoMini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
      
            // === PREPARACIÓN VISUAL ===
            guna2WinProgressIndicator1.Visible = true;
            guna2WinProgressIndicator1.Start();
            guna2GradientButton1.Enabled = false;

            try
            {
                // 1. Configurar conexión a MongoDB
                string connectionString = "mongodb://localhost:27017/";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Base_datos_Reunion");
                var collection = database.GetCollection<BsonDocument>("Usuario");

                // 2. Obtener valores
                int idIngresado = int.Parse(txtID.Text);
                int passIngresada = int.Parse(txtPassword.Text);

                // 3. Crear filtro
                var filtro = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("_id.ID", idIngresado),
                    Builders<BsonDocument>.Filter.Eq("Contraseña", passIngresada)
                );

                // 4. Ejecutar búsqueda
                var usuarioEncontrado = collection.Find(filtro).FirstOrDefault();

                // 5. Validar resultado
                if (usuarioEncontrado != null)
                {
                    string nombres = usuarioEncontrado["Nombres"].AsString;
                    string tipoUsuario = usuarioEncontrado["Tipo_Usuario"].AsString;

                    MessageBox.Show($"¡Bienvenido {nombres}!\nHas ingresado como: {tipoUsuario}",
                                    "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (tipoUsuario == "Lider")
                    {
                        Lider ventanaLider = new Lider(nombres, tipoUsuario);
                        ventanaLider.Show();
                    }
                    else if (tipoUsuario == "Investigador")
                    {
                        Investigador ventanaInv = new Investigador(nombres, tipoUsuario);
                        ventanaInv.Show();
                    }

                    this.Hide();
                }
                else
                {
                    // === CASO: CREDENCIALES INCORRECTAS ===
                    MessageBox.Show("El ID o la contraseña son incorrectos.",
                                    "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // DETENER ANIMACIÓN AQUÍ
                    DetenerCarga();
                }
            }
            catch (FormatException)
            {
                // === CASO: LETRAS EN LUGAR DE NÚMEROS ===
                MessageBox.Show("Por favor, ingresa únicamente números en los campos de ID y Contraseña.",
                                "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // DETENER ANIMACIÓN AQUÍ
                DetenerCarga();
            }
            catch (Exception ex)
            {
                // === CASO: ERROR DE BASE DE DATOS O RED ===
                MessageBox.Show("Error al intentar conectar con la base de datos:\n" + ex.Message,
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // DETENER ANIMACIÓN AQUÍ
                DetenerCarga();
            }
        }

        // Creamos este pequeño método para no repetir las mismas 3 líneas en cada error
        private void DetenerCarga()
        {
            guna2WinProgressIndicator1.Stop();
            guna2WinProgressIndicator1.Visible = false;
            guna2GradientButton1.Enabled = true; // Volvemos a habilitar el botón para que reintente
        }
    }
}


