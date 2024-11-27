    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string telefono { get; set; }


        public Usuario() { }


        public Usuario(int id, string usuario, string clave, string telefono)
        {

            this.Id = id;
            this.usuario = usuario;
            this.clave = clave;
            this.telefono = telefono;



        }
    }
}