using Capa_Entidades;
using Logica_capa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using Visual;

namespace MiAplicacion
{
    public partial class Empleados : FormularioPrincipal
    {
        Empleado empleado = new Empleado();
        Logica_empleado l_empleado = new Logica_empleado();
        public Empleados()
        {
            InitializeComponent();
            gridEmpleados.AutoGenerateColumns = true;
            gridEmpleados.ReadOnly = true;
            gridEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtSueldobase.MaxLength = 10;
            txtCedula.MaxLength = 11;

            cargarEmpleados();


        }

        private void cargarEmpleados()
        {

            DataTable empleados = l_empleado.cargarEmpleados();


            if (empleados.Rows.Count > 0)
            {
                gridEmpleados.DataSource = empleados;
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cc = txtCedula.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = 0;
            int sueldo_base = 0;

            string telefono = txttelefono.Text;
            string rol = empleado.rol;

            if (!string.IsNullOrEmpty(cc) &&
     !string.IsNullOrEmpty(nombre) &&
     !string.IsNullOrEmpty(apellido) &&
     !string.IsNullOrEmpty(telefono) &&
     !string.IsNullOrEmpty(rol) &&
     !string.IsNullOrEmpty(txtEdad.Text) &&
     !string.IsNullOrEmpty(txtSueldobase.Text))
            {
                if (int.TryParse(txtEdad.Text, out int parsedEdad) && int.TryParse(txtSueldobase.Text, out int parsedSueldoBase))
                {
                    edad = parsedEdad;
                    sueldo_base = parsedSueldoBase;


                    empleado.cc = cc;
                    empleado.nombre = nombre;
                    empleado.apellido = apellido;
                    empleado.edad = edad;
                    empleado.sueldo_base = sueldo_base;
                    empleado.telefono = telefono;

                    l_empleado.añadirEmpleado(empleado);
                    cargarEmpleados();
                }
                else
                {
                    MessageBox.Show("Campos Vacios");
                }










                LimpiarCampos();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string cc = txtCedulaEliminar.Text;
            bool clienteEliminado = eliminar(cc);

            empleado.cc = cc;
            l_empleado.eliminarEmpleado(empleado);
            if (clienteEliminado)
            {
                MessageBox.Show("Cliente eliminado");
                cargarEmpleados();
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
            int sueldo_base = Int32.Parse(txtEdad.Text);

            string telefono = txtSueldobase.Text;

            if (!string.IsNullOrEmpty(cc) &&
                !string.IsNullOrEmpty(nombre) &&
                !string.IsNullOrEmpty(apellido) &&
                !string.IsNullOrEmpty(telefono))
            {

                empleado.cc = cc;
                empleado.nombre = nombre;
                empleado.apellido = apellido;
                empleado.edad = edad;
                empleado.telefono = telefono;
                empleado.sueldo_base = sueldo_base;

                l_empleado.editarEmpleado(empleado);
                cargarEmpleados();
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
            txtSueldobase.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtCedulaEliminar.Text = string.Empty;

        }


        private bool eliminar(string cc)
        {
            empleado.cc = cc;
            bool eliminado = l_empleado.eliminarEmpleado(empleado);
            return eliminado;

        }

        private void txtCedula_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mandarEliminar(txtCedulaEliminar, gridEmpleados);

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar(gridEmpleados, "nombre", txtBuscar); 

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(gridEmpleados, "nombre", txtBuscar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            empleado.rol = button1.Text;

            button1.BackColor = Color.Gray;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.BackColor = Color.Green;

            empleado.rol = button1.Text;

            button2.BackColor = Color.Gray;

        }
    }
}
