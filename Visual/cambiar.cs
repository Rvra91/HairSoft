using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class cambiar : Form
    {
        public cambiar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("SE LE ENVIARA UN CODIGO A SU CELULAR QUE DEBERA INGRESAR EN EL APARTADO DE CODIGO+/n" +
                "Una vez se verifique el codigo correcto, podra cambiar su contraseña u usuario");



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
