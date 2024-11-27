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
using Logica_capa;
namespace Visual
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        public void cargarGrid(Object objeto, Func<DataTable> funcion, DataGridView grid)
        {
            // Ejecuta la función proporcionada en el objeto y obtiene el DataTable
            DataTable gridd = funcion();

            // Verifica si el DataTable contiene filas
            if (gridd.Rows.Count > 0)
            {
                // Asigna el DataTable como fuente de datos al GridServicios
                grid.DataSource = gridd;
            }
        }


        public void buscar(DataGridView grid ,string columna, TextBox txt) { 


               
            (grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("{0} LIKE '{1}%' ", columna, txt.Text);
        }

        public void mandarEliminar(TextBox txt, DataGridView grid)
        {

            try
            {
                txt.Text = Convert.ToString(grid.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void mandarEditar(TextBox txt, DataGridView grid)
        {

            try
            {
                txt.Text = Convert.ToString(grid.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception ex)
            {
                return;
            }

        }
        public bool moverse(object sender, KeyPressEventArgs e, TextBox txt)
        {
            bool mover = false;
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Acción a realizar cuando se presiona Enter
                txt.Focus();
                e.Handled = true;  // Opcional: evita el sonido "ding" de Enter
            }
            return mover = true;
        }
        
    }
}
