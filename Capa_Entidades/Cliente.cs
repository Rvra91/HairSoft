using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Cliente : Persona
    {


        public Cliente() { }


        public Cliente (string cc, string nombre, string apellido, int edad, string telefono) {
            this.cc = cc;
            this.nombre = nombre;
            this.apellido = apellido;  
            this.edad = edad;
            this.telefono = telefono;


        }
    }
}
