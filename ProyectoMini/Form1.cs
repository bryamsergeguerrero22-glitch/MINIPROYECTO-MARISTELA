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
                var usuarioEncontrado = collection.Find(filtro).FirstOrDefault();//Busca todo los documentos que cumplan con el filtro, trae el primer resultado y si no lo muestra nulo en else

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
                    //CASO: CREDENCIALES INCORRECTAS
                    MessageBox.Show("El ID o la contraseña son incorrectos.",
                                    "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Limpiar campos
                    LimpiarCampos();

                    // DETENER ANIMACIÓN AQUÍ
                    DetenerCarga();
                }
            }
            catch (Exception ex)
            {
                // === CASO: ERROR DE BASE DE DATOS O RED ===
                MessageBox.Show("\n" + ex.Message,
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Limpiar campos
                LimpiarCampos();

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



        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite números", "Información importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtPassword.Text = "";
            txtID.Focus(); 
        }

        
    }
}


