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
                dt.Columns.Add("Estado"); // Nueva columna para el estado

                DateTime ahora = DateTime.Now;

                foreach (var doc in resultados)
                {
                    string fechaStr = doc.Contains("fechaReunion") ? doc["fechaReunion"].ToString() : "";
                    string inicioStr = doc.Contains("horaInicio") ? doc["horaInicio"].ToString() : "";
                    string finStr = doc.Contains("horaFin") ? doc["horaFin"].ToString() : "";

                    string estado = "N/A";

                    // Lógica para calcular el estado
                    if (!string.IsNullOrEmpty(fechaStr) && !string.IsNullOrEmpty(inicioStr) && !string.IsNullOrEmpty(finStr))
                    {
                        try
                        {
                            // Combinamos fecha y hora para comparar correctamente
                            DateTime fechaReunion = DateTime.Parse(fechaStr);
                            DateTime horaInicio = DateTime.Parse(fechaStr + " " + inicioStr);
                            DateTime horaFin = DateTime.Parse(fechaStr + " " + finStr);

                            if (ahora < horaInicio)
                                estado = "Programada";
                            else if (ahora >= horaInicio && ahora <= horaFin)
                                estado = "Iniciada";
                            else
                                estado = "Finalizada";
                        }
                        catch { estado = "Error Formato"; }
                    }

                    dt.Rows.Add(
                        doc["_id"].ToString(),
                        fechaStr,
                        inicioStr,
                        finStr,
                        doc.Contains("descripcionReunion") ? doc["descripcionReunion"].ToString() : "Sin descripción",
                        doc.Contains("Lugar") ? doc["Lugar"].ToString() : "N/A",
                        doc.Contains("Creador") ? doc["Creador"].ToString() : "Desconocido",
                        estado
                    );
                }
                guna2DataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message);
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

            guna2DataGridView1.DataSource = dt;
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
                    guna2DataGridView1.DataSource = null;
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

        private void txtValorBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}