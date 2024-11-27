using Logica_capa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidades;
namespace Visual
{
    public partial class AgregarCita : Form
    {
        Capa_Entidades.Cita cita = new Capa_Entidades.Cita();
      
        public AgregarCita()
        {
            InitializeComponent();
            fechaCita.Format = DateTimePickerFormat.Custom;
            fechaCita.CustomFormat = "yyyy-MM-dd HH:mm";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarCita_Load(object sender, EventArgs e)
        {

                


        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

             DateTime fecha = fechaCita.Value;

            string cc_cliente = " ";

             cita.fecha = fecha;
            cita.cc_cliente = cc_cliente;
            cita.cc_empleado = cc_cliente;
             
            
            







        }

        private void btnservicio_Click(object sender, EventArgs e)
        {
            
        }
    }
}
