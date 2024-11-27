using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica_capa;
using Capa_Entidades;
namespace Visual
{
    public partial class Login : Form
    {
        Usuario u = new Usuario();

        Logica_usuario usuario = new Logica_usuario();
        public Login()
        {
            InitializeComponent();
        
         }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            logIn();
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Acción a realizar cuando se presiona Enter
                logIn();
                e.Handled = true;  // Opcional: evita el sonido "ding" de Enter
            }
        
        }


        public void logIn()
        {
 

     

            string user = txtuser.Text;
            string password = txtpassword.Text;
            u.usuario = user;
            u.clave = password;
            if (usuario.IniciarSesion(u))
            {
                MessageBox.Show("Login correcto");
                Dashboard d = new Dashboard();
                d.Show();
                d.FormClosed += (s, args) => this.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Incorrecto");
            }
        }

        private void t(object sender, EventArgs e)
        {

        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Acción a realizar cuando se presiona Enter
                txtpassword.Focus();
                e.Handled = true;  // Opcional: evita el sonido "ding" de Enter
            }

        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            logIn();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
