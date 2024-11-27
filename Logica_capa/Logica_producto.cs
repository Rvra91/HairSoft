using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_datos;
using System.Data;


namespace Logica_capa
{
    public class Logica_producto
    {

        public bool agregarProducto(Productos producto)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO PRODUCTOS(NOMBRE, DESCRIPCION, PRECIO) VALUES (@nombre, @descripcion ,@precio);"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombre", producto.nombre);
                    comando.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    comando.Parameters.AddWithValue("@precio", producto.precio);
 

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

                Console.WriteLine("Error al agregar el producto: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }
        public DataTable cargarProductos()
        {

            DataTable citas = new DataTable();
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT * FROM PRODUCTOS;";
                    SqlCommand comando = new SqlCommand(sql, conexion);

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(citas); // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar los clientes: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas
                throw ex;
            }

            return citas;
        }



        public bool eliminarProducto(Productos producto)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "DELETE PRODUCTOS WHERE ID = @id  ;"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id", producto.id);
                  


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

                Console.WriteLine("Error al agregar el producto: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }
    }
}
