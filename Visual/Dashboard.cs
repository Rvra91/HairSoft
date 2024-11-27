using Capa_Entidades;
using MiAplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Visual
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Login l = new Login();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            desplazar(new Cita());
        }

        private Form activeForm = null;
        public void desplazar(Form hijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;

            panelHijo.Controls.Clear(); // Limpiar antes de agregar el nuevo formulario
            panelHijo.Controls.Add(hijo);
            panelHijo.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }



        private void btnusuario_Click(object sender, EventArgs e)
        {

        }

        private void btnservicio_Click(object sender, EventArgs e)
        {
            desplazar(new Servicios());
        }

        private void btncliente_Click(object sender, EventArgs e)
        {


            desplazar(new Clientes());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            desplazar(new cambiar());

        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            desplazar(new Empleados());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la ruta al directorio base del proyecto Windows Forms
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;

                // Construir la ruta relativa a la carpeta del proyecto Bot
                // Esto asume que Bot está al mismo nivel que ProyectoForm
                string rutaBot = Path.Combine(rutaBase, @"..\..\Bot\net8.0\Bot.exe");

                // Convertir la ruta a una ruta absoluta
                rutaBot = Path.GetFullPath(rutaBot);

                // Verificar que el archivo ejecutable exista
                if (File.Exists(rutaBot))
                {
                    // Mostrar la ruta completa para depuración
 
                    // Configurar el proceso para ejecutar el archivo .exe
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = rutaBot,  // Ruta al archivo ejecutable
                        UseShellExecute = true  // Usar el sistema operativo para ejecutar el proceso
                    };

                    // Iniciar el proceso (ejecuta el archivo .exe de la consola)
                    Process.Start(startInfo);
                }
                else
                {
                    // Mostrar mensaje si el archivo no existe
                    MessageBox.Show($"El archivo ejecutable no se encuentra en la ruta especificada: {rutaBot}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show($"Error al intentar ejecutar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Lanzar la excepción nuevamente si se quiere propagar el error
             }
        }
    }
}