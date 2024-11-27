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
 namespace Visual
{
    public partial class Cita : FormularioPrincipal
    {

        private Timer timer;

        Logica_cita citas = new Logica_cita();
        Capa_Entidades.Cita  cita= new Capa_Entidades.Cita();
        public Cita()
        {

            InitializeComponent();
            cargarGrid(cita, citas.cargarCitas, gridCita);
            gridCita.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
 

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarCita ccc = new AgregarCita();

            ccc.Show();

        }

       
        



 

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {


            
 
                cita.id = Int32.Parse(lblid.Text);

                citas.validarCita(cita,1);
                cargarGrid(cita, citas.cargarCitas, gridCita);
           


            citas.validarCita(cita, 1);
        }

        private void gridCita_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verifica que haya una fila seleccionada y que no sea el encabezado
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow filaSeleccionada = gridCita.Rows[e.RowIndex];

                // Asigna los valores de las celdas a los labels
                lblid.Text = filaSeleccionada.Cells["id"].Value.ToString();
                lblcliente.Text = filaSeleccionada.Cells["nombre_cliente"].Value.ToString();
                lblempleado.Text = filaSeleccionada.Cells["nombre_empleado"].Value.ToString();

            }


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(gridCita, "nombre_cliente", txtBuscar);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            string id = lblid.Text; 

            if (id is null)
            {


            }
            else
            {
                cita.id = Int32.Parse(lblid.Text);
                
                citas.eliminarCita(cita);
                cargarGrid(cita, citas.cargarCitas, gridCita);
            }
 


        }

        private void gridCita_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Logica_servicio logica_Servicio = new Logica_servicio();    

                if (e.RowIndex >= 0)
                {
                    // Obtén la fila seleccionada
                    DataGridViewRow filaSeleccionada = gridCita.Rows[e.RowIndex];

                    // Asigna los valores de las celdas a los labels
                    lblid.Text = filaSeleccionada.Cells["id"].Value.ToString();
                    lblcliente.Text = filaSeleccionada.Cells["nombre_cliente"].Value.ToString();
                    lblempleado.Text = filaSeleccionada.Cells["nombre_empleado"].Value.ToString();

                    int id_servicio = Convert.ToInt32(filaSeleccionada.Cells["id_servicio"].Value);

                    lblservicio.Text = logica_Servicio.obtenerNombre(id_servicio);
                    lblprecio.Text = logica_Servicio.obtenerPrecio(id_servicio).ToString();



                    int estado = int.Parse(filaSeleccionada.Cells["estado"].Value.ToString());

                    if (estado == 0)
                    {

                        lblestado.Text = "Activo";
                        lblestado.BackColor = System.Drawing.Color.FromArgb(0, 128, 0); // Verde personalizado
                    }
                    else if (estado == 1)
                    {


                        lblestado.Text = "Terminado";

                    }
                    else if (estado == 2)
                    {


                        lblestado.Text = "Vencido";
                        lblestado.BackColor = System.Drawing.Color.Red;

                    }

                }
            }
            catch
            {



            }
          

        }

        private void gridCita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnefectivo_Click(object sender, EventArgs e)
        {

            cargarGrid(cita, citas.cargarCitas, gridCita);




        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
