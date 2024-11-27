using Capa_datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_capa
{
    public class Logica_empleado



    {
        
        public DataTable cargarEmpleados()
        {

            DataTable clientes = new DataTable();
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "SELECT * FROM EMPLEADOS"; // O las columnas que desees cargar
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

        public bool añadirEmpleado(Empleado empleado)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "INSERT INTO EMPLEADOS(CC,NOMBRE, APELLIDO, SUELDO_BASE, EDAD, ROL,CONTACTO) VALUES (@cc, @nombre,@apellido,@sueldo_base,@edad,@rol,@telefono);"; // O las columnas que desees cargar
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", empleado.cc);

                    comando.Parameters.AddWithValue("@nombre", empleado.nombre);
                    comando.Parameters.AddWithValue("@apellido", empleado.apellido);
                    comando.Parameters.AddWithValue("@edad", empleado.telefono);
                    comando.Parameters.AddWithValue("@telefono", empleado.telefono);
                    comando.Parameters.AddWithValue("@sueldo_base", empleado.sueldo_base);
                    comando.Parameters.AddWithValue("@rol", empleado.rol);



                    int filasAfectadas = comando.ExecuteNonQuery();

                     if (filasAfectadas > 0)
                    {
                        crearservicio = true;
                    }
                 }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al agregar el empleado: " + ex.Message);
             }

            return crearservicio;
        }

        public bool eliminarEmpleado(Empleado empleado)
        {

            bool borrar = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "DELETE FROM EMPLEADOS WHERE CC= @CC;";  
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", empleado.cc);



                     int filasAfectadas = comando.ExecuteNonQuery();

                     if (filasAfectadas > 0)
                    {
                        borrar = true;
                    }
                 }



            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al borrar el empleado: " + ex.Message);
                 throw;
            }

            return borrar;
        }


        public bool editarEmpleado(Empleado empleado)
        {

            bool crearservicio = false;
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string sql = "UPDATE EMPLEADOS SET cc=@cc NOMBRE = @nombre, APELLIDO = @apellido, EDAD = @edad,telefono =@telefono," +
                        "sueldo_base = @sueldo_base WHERE CC = @cc;";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@cc", empleado.cc);

                    comando.Parameters.AddWithValue("@nombre", empleado.nombre);
                    comando.Parameters.AddWithValue("@apellido", empleado.apellido);
                    comando.Parameters.AddWithValue("@edad", empleado.edad);
                    comando.Parameters.AddWithValue("@sueldo_base", empleado.sueldo_base);


                    int filasAfectadas = comando.ExecuteNonQuery();

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
                // Opcional: Puedes lanzar la excepción si deseas manejarla más arriba en la cadena de llamadas

            }

            return crearservicio;
        }

    }
}
