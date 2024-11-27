using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_datos;
using Capa_Entidades;
using Oracle.ManagedDataAccess.Client;
namespace Logica_capa
{
    public class Logica_cliente
    {
     public DataTable cargarClientes()
        {

            DataTable clientes = new DataTable();
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT * FROM CLIENTES"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(clientes); // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar los clientes: " + ex.Message);

            }

            return clientes;


        }

        public bool agregarCliente(Cliente cliente)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO CLIENTES(CC,NOMBRE, APELLIDO, EDAD) VALUES (@cc, @nombre,@apellido,@edad);"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", cliente.cc);

                    comando.Parameters.AddWithValue("@nombre", cliente.nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.apellido);
                    comando.Parameters.AddWithValue("@edad", cliente.edad);
 

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Si se afectaron filas, la inserción fue exitosa
                    if (filasAfectadas > 0)
                    {
                        crearservicio = true;
                    }
                 }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al agregar el cliente: " + ex.Message);

                throw;
 
            }

            return crearservicio;
        }
        public bool eliminarCliente(Cliente cliente)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "DELETE FROM CLIENTES WHERE CC= @cc;"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", cliente.cc);
 

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Si se afectaron filas, la inserción fue exitosa
                    if (filasAfectadas > 0)
                    {
                        crearservicio = true;
                    }
                    // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al agregar el servicio: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas
                throw;
            }

            return crearservicio;
        }


        public bool editarCliente(Cliente cliente)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "UPDATE CLIENTES SET NOMBRE = @nombre, APELLIDO = @apellido, EDAD = @edad, WHERE CC = @cc;";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", cliente.cc);

                    comando.Parameters.AddWithValue("@nombre", cliente.nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.apellido);
                    comando.Parameters.AddWithValue("@edad", cliente.edad);
 

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Si se afectaron filas, la inserción fue exitosa
                    if (filasAfectadas > 0)
                    {
                        crearservicio = true;
                    }
                    // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al agregar el cliente: " + ex.Message);

                throw;
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }

        public bool verificarCliente(Cliente cliente)
        {
            bool existe = false;

            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT COUNT(*) FROM CLIENTES WHERE CC = @cc";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", cliente.cc);

                    // Ejecuta el comando directamente, sin abrir la conexión explícitamente
                    int count = (int)comando.ExecuteScalar();
                    existe = (count > 0); // Será true si el cliente existe
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar el cliente: " + ex.Message);
                throw; // Opcional: puedes lanzar la excepción para manejarla a un nivel superior
            }

            return existe;
        }





    }
}
 
