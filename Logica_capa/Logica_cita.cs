using Capa_datos;
using Capa_Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_capa
{
    public class Logica_cita
    {

        public DataTable cargarCitas()
        {

            DataTable citas = new DataTable();
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = @"
    SELECT 
        CITA.ID,
        CITA.FECHA,
        CITA.TIPO_PAGO,
        CITA.ESTADO,
        CLIENTES.NOMBRE AS NOMBRE_CLIENTE,
        EMPLEADOS.NOMBRE AS NOMBRE_EMPLEADO
    FROM 
        CITA
    INNER JOIN CLIENTES ON CITA.CC_CLIENTE = CLIENTES.CC
    INNER JOIN EMPLEADOS ON CITA.CC_EMPLEADO = EMPLEADOS.CC"; SqlCommand comando = new SqlCommand(sql, conexion);

                    // Usamos un SqlDataAdapter para llenar el DataTable
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(citas); // Llena el DataTable con los datos obtenidos
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar las citas: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas
                throw ex;
            }

            return citas;
        }
        public bool agregarCita(Cita cita)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO CITA(FECHA, CC_CLIENTE, CC_EMPLEADO, TIPO_PAGO, ID_SERVICIO) VALUES (@fecha, @cc_cliente,@cc_empleado,@tipo_pago,@id_servicio);"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@fecha", cita.fecha);
                    comando.Parameters.AddWithValue("@cc_cliente", cita.cc_cliente);
                    comando.Parameters.AddWithValue("@cc_empleado", cita.cc_empleado);
                    comando.Parameters.AddWithValue("@tipo_pago", cita.tipo_pago);
                    comando.Parameters.AddWithValue("@id_servicio", cita.id_servicio);


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

                Console.WriteLine("Error al agregar la cita: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }
        public bool eliminarCita(Cita cita)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "  DELETE CITA WHERE ID= @id;"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id", cita.id);
                   

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

                Console.WriteLine("Error al agregar la cita: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }
        public bool cita_servicios(Cita cita, Servicio servicio)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO CITA_SERVICIOS(ID_CITA, ID_SERIVICIO, ) VALUES (@fecha, @cc_cliente,@cc_empleado,@tipo_pago );"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id_cita", cita.id);
                    comando.Parameters.AddWithValue("@servicio_id", servicio.id);
                  


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

                Console.WriteLine("Error al juntar la cita con servicio: " + ex.Message);
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }

        public void validarCita(Cita cita, int estado)
        {


             try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "UPDATE CITA SET ESTADO = @estado WHERE ID = @id_cita;";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id_cita", cita.id);
                    comando.Parameters.AddWithValue("@estado", estado);



                     int filasAfectadas = comando.ExecuteNonQuery();

                     if (filasAfectadas > 0)
                    {
                     }
                 }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al juntar al validar la cita: " + ex.Message);
                 throw new Exception(ex.Message); 
            }

        }
    }


}
