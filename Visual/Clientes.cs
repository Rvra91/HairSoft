using Capa_Entidades;
using Logica_capa;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using Visual;

namespace MiAplicacion
{
    public partial class Clientes : FormularioPrincipal
    {
        Cliente cliente = new Cliente();
        Logica_cliente c = new Logica_cliente();
        public Clientes()
        {
            InitializeComponent();
            gridClientes.AutoGenerateColumns = true;
            gridClientes.ReadOnly = true;
            gridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             txtCedula.MaxLength = 10;

            cargarClientes();


        }

        private void cargarClientes()
        {

            DataTable clientes = c.cargarClientes();


            if (clientes.Rows.Count > 0)
            {
                gridClientes.DataSource = clientes;
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                string cc = txtCedula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int edad = Int32.Parse(txtEdad.Text);

 
                if (!string.IsNullOrEmpty(cc) &&
                    !string.IsNullOrEmpty(nombre) &&
                    !string.IsNullOrEmpty(apellido)  )
                {

                    cliente.cc = cc;
                    cliente.nombre = nombre;
                    cliente.apellido = apellido;
                    cliente.edad = edad;
                     c.agregarCliente(cliente);
                    cargarClientes();
                }
                else
                {
                    MessageBox.Show("Campos Vacios");
                }










                LimpiarCampos();


            }
            catch (Exception ex)
            {

            }
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cc = txtCedulaEliminar.Text;
            bool clienteEliminado = eliminar(cc);

            cliente.cc = cc;
            c.eliminarCliente(cliente);
            if (clienteEliminado)
            {
                MessageBox.Show("Cliente eliminado");
                cargarClientes();
            }
            else
            {
                MessageBox.Show(cc, " Cliente no existe");
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

            string cc = txtCedula.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Int32.Parse(txtEdad.Text);

 
            if (!string.IsNullOrEmpty(cc) &&
                !string.IsNullOrEmpty(nombre) &&
                !string.IsNullOrEmpty(apellido)  )
            {

                cliente.cc = cc;
                cliente.nombre = nombre;
                cliente.apellido = apellido;
                cliente.edad = edad;
                 c.editarCliente(cliente);
                cargarClientes();
            }
            else
            {
                MessageBox.Show("Campos Vacios");
            }










            LimpiarCampos();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCedula.Text = string.Empty;
             txtEdad.Text = string.Empty;
            txtCedulaEliminar.Text = string.Empty;

        }


        private bool eliminar(string cc)
        {
            cliente.cc = cc;
            bool eliminado = c.eliminarCliente(cliente);
            return eliminado;

        }

        private void txtCedula_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mandarEliminar(txtCedulaEliminar, gridClientes);

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar(gridClientes, "nombre", txtBuscar); 

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(gridClientes, "nombre", txtBuscar);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento si no es un número o una tecla de control
            }
            moverse(sender, e, txtNombre);

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            moverse(sender, e, txtApellido);

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
 

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (moverse(sender, e, txtCedula))
                {


                    string cc = txtCedula.Text;
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    int edad = Int32.Parse(txtEdad.Text);

 
                    if (!string.IsNullOrEmpty(cc) &&
                        !string.IsNullOrEmpty(nombre) &&
                        !string.IsNullOrEmpty(apellido)  )
                    {

                        cliente.cc = cc;
                        cliente.nombre = nombre;
                        cliente.apellido = apellido;
                        cliente.edad = edad;
                         c.agregarCliente(cliente);
                        cargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Campos Vacios");
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
               
            

        

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            moverse(sender, e, txtEdad);

        }
    }
}
