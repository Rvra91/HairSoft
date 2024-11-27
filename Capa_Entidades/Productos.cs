using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Productos
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio
        {
            get; set;

        }


        public Productos()
        {
        }

        public Productos (int id, string nombre, string descripcion, int precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }
}
