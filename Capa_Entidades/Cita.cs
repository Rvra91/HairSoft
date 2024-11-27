using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Cita
    {

        public int id { get; set; }
        public DateTime fecha { get; set; } 
        public string tipo_pago { get; set; }
        public string cc_cliente { get; set; }

        public string cc_empleado { get; set; }

        public int estado { get; set; }
        public int id_servicio { get; set; }


        public Cita() { }

        public Cita(int id , DateTime fecha, string tipo_pago, int estado, int id_servicio)
        {
            this.id = id;
            this.fecha = fecha;
          
            this.tipo_pago  = tipo_pago;
            this.estado = estado;
            this.id_servicio = id_servicio; 
        }
 


    }
}
