using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
 using System.Security.Cryptography.X509Certificates;

namespace Capa_datos
{
    public class Conexion 
    {

        public static SqlConnection conectar()
        {
            // Actualiza la cadena de conexión para usar autenticación de SQL Server
            string connectionString = "Server=EDUARDO;Database=PELUQUERIA;Integrated Security=True;Connection Timeout=30;";

            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
return conexion;
        }


    }
}