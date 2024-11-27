using Logica_capa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidades;
namespace Visual
{
    public partial class Servicios : FormularioPrincipal
    {

        Servicio servicio = new Servicio();
        Logica_servicio servicios = new Logica_servicio();

        public Servicios()
        {
            InitializeComponent();
            cargarGrid(servicios,servicios.cargarServicios, GridServicios );
            GridServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtid.Text = "0";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            agregarServicio();

        }


       
     

     
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            moverse(sender, e, txtPrecio);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            moverse(sender, e, txtDescuento);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            moverse(sender, e, txtDescripcion);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(moverse(sender, e, txtNombre))
            { 
               

                agregarServicio();

                
            }

            
         
        }

        public bool agregarServicio()
        {
            bool agregado = false;
            int descuento;
            Logica_servicio s = new Logica_servicio();

            if (string.IsNullOrEmpty(txtNombre.Text) &&
                string.IsNullOrEmpty(txtDescuento.Text) &&
                    string.IsNullOrEmpty(txtPrecio.Text) &&
                string.IsNullOrEmpty(txtDescripcion.Text))
            {

                MessageBox.Show("Espacios vacios");

            }
            else
            {

                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;


                int precio = Int32.Parse(txtPrecio.Text);

                if (string.IsNullOrEmpty(txtDescuento.Text))
                {
                    descuento = 0;
                }
                else
                {
                    descuento = Int32.Parse(txtDescuento.Text);

                }
                servicio.nombre = nombre;
                servicio.descripcion = descripcion;
                servicio.precio = precio;
                servicio.descuento = descuento;


                if(s.crearServicio(servicio))
                {
                    cargarGrid(servicios, servicios.cargarServicios, GridServicios);
                    agregado = true;
                }
                else
                {

                    MessageBox.Show("Cliente no existe");
                }


              
            }
            return agregado;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
       
            int id = Int32.Parse(txtid.Text);
                servicio.id = id;


            if (servicios.eliminarServicio(servicio))
            {


                MessageBox.Show("Servicio Eliminado");
                cargarGrid(servicios, servicios.cargarServicios, GridServicios);
            }
            else
            {
             }


        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar(GridServicios, "NOMBRE", txtbuscar);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(GridServicios, "NOMBRE", txtbuscar);

        }
    }
}
