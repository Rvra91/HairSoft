using Capa_datos;
using Capa_Entidades;
 using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_capa
{
    public class Logica_servicio
    {

        public int obtenerPrecio(int id)
        {
            int precio = 0;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT PRECIO FROM SERVICIOS WHERE ID = @id";
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    comando.Parameters.AddWithValue("@id", id);

                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        precio = Convert.ToInt32(result); // Corrige aquí
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
            }

    

            return precio;
        }

        public string obtenerNombre(int id)
        {
            string nombre = "";
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT NOMBRE FROM SERVICIOS WHERE ID = @id";
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    comando.Parameters.AddWithValue("@id", id);

                    object result = comando.ExecuteScalar();
                    if (result != null)
                    {
                        nombre = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el nombre del servicio: " + ex.Message);
                // Solo logueamos el error sin lanzar la excepción
            }

            return nombre;
        }



        public DataTable cargarServicios()
        {
            DataTable tablaservicio = new DataTable();
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT * FROM SERVICIOS"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(tablaservicio); // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar los servicios: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas
             
            }
           
            return tablaservicio;
        }

        public bool crearServicio(Servicio servicio)
        {

            bool crearservicio = false;
             try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO SERVICIOS(NOMBRE, DESCRIPCION, PRECIO, DESCUENTO) VALUES (@nombre, @descripcion,@precio,@descuento );"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombre", servicio.nombre);
                    comando.Parameters.AddWithValue("@descripcion", servicio.descripcion);
                    comando.Parameters.AddWithValue("@precio", servicio.precio);
                    comando.Parameters.AddWithValue("@descuento", servicio.descuento);
 

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
              
            }

            return crearservicio;
        }

        public bool eliminarServicio(Servicio servicio)
        {

            bool borrar = false;
             try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "DELETE FROM SERVICIOS WHERE ID= @id;"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id", servicio.id);
     


                    // Usamos un SqlDataAdapter para llenar el DataTable
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Si se afectaron filas, la inserción fue exitosa
                    if (filasAfectadas > 0)
                    {
                        borrar = true;
                    }
                    // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al borrar los servicios: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas
                throw;
            }

            return borrar;
        }
    }
}

