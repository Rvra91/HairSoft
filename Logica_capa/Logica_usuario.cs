using Capa_datos;
using Capa_Entidades;
using Microsoft.Win32;
using Oracle.ManagedDataAccess.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_capa
{
    public class Logica_usuario
    {



        public bool IniciarSesion(Usuario usuario)
        {
            bool login = false;
            int retorna = 0;
            using (SqlConnection conexion = Conexion.conectar())
            {
                // Usando parámetros para evitar inyección SQL
                string sql = "SELECT COUNT(*) FROM USUARIO WHERE USUARIO = @usuario AND CLAVE = @clave";
                SqlCommand comando = new SqlCommand(sql, conexion);

                // Agregar los parámetros
                comando.Parameters.AddWithValue("@usuario", usuario.usuario);
                comando.Parameters.AddWithValue("@clave", usuario.clave);

                // Ejecutar el comando y obtener el número de registros que coinciden
                retorna = (int)comando.ExecuteScalar();
            }

            // Si no se encontró el usuario y clave, retorna false
            if (retorna == 0)
            {
                return login = false;
            }
            else
            {
                login = true;
            }
            return login;
        }



    }

}
