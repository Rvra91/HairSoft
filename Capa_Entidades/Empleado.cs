using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Empleado : Persona
    { 

        public int sueldo_base {  get; set; }
        public string rol {  get; set; }


        public Empleado() { }

        public Empleado(string cc, string nombre, string apellido, int edad, string telefono, int sueldo_base, string rol)
        {

            this.cc = cc;
            this.nombre = nombre;
                
            this.apellido = apellido;
              this.telefono = telefono;
            this.edad = edad;
            this.sueldo_base = sueldo_base;
            this.rol = rol;
        }

    }



}
