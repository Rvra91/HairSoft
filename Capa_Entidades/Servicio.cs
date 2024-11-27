using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Servicio
    {

    public int id {  get; set; }
        public string nombre { get; set; }
        public double precio {  get; set; }
        public string descripcion { get; set; }
        public int descuento { get; set; }
        

        
        public Servicio() { }

        public Servicio(int id, string nombre, double precio, string descripcion,int descuento   )
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.descuento = descuento;
      
        }
    }
}
