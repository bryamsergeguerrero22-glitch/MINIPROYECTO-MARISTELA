using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMini
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Se comenta la siguiente línea para permitir que el MonthCalendar 
            // cambie su color de fondo (BackColor) al verde menta.
            // Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciamos con Form1 (asegúrate de que este es el formulario que quieres abrir primero)
            Application.Run(new Form1());
        }
    }
}