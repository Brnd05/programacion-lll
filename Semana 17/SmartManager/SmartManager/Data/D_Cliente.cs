using SmartManager.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Datos
{
    public class D_Cliente
    {
       

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = null;
            SqlDataReader resultado = null;

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand("MostrarClientes", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    resultado = cmd.ExecuteReader();
                    tabla.Load(resultado);
                }
            }
            finally
            {
                if (resultado != null && !resultado.IsClosed) resultado.Close();
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return tabla;
        }



        public string InsertarCliente(string nombre, string apellido, string email)
        {
            string respuesta = "OK";
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand comando = new SqlCommand("sp_InsertarCliente", sqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar, 100).Value = nombre;
                    comando.Parameters.Add("@apellido_cliente", SqlDbType.NVarChar, 100).Value = apellido;
                    comando.Parameters.Add("@email_cliente", SqlDbType.NVarChar, 250).Value = email;

                    int filas = comando.ExecuteNonQuery();
                    if (filas < 1) respuesta = "No se insertó ningún registro";
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) 
            {
                respuesta = "El email ya existe. Debe ser único.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }

        
        public string ActualizarCliente(int idCliente, string nombre, string apellido, string email)
        {
            string respuesta = "OK";
            SqlConnection sqlCon = null;

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand comando = new SqlCommand("sp_ActualizarCliente", sqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("@id_cliente", SqlDbType.Int).Value = idCliente; 
                    comando.Parameters.Add("@nombre_cliente", SqlDbType.NVarChar, 100).Value = nombre;
                    comando.Parameters.Add("@apellido_cliente", SqlDbType.NVarChar, 100).Value = apellido;
                    comando.Parameters.Add("@email_cliente", SqlDbType.NVarChar, 250).Value = email;

                    int filas = comando.ExecuteNonQuery(); 
                    if (filas < 1) respuesta = "No se actualizó ningún registro";
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                respuesta = "El email ya existe. Debe ser único.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }

    
        public string EliminarCliente(int idCliente)
        {
            string respuesta = "OK";
            SqlConnection sqlCon = null;

            try
            {
                
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand comando = new SqlCommand("sp_EliminarCliente", sqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure; // corrected variable name
                    comando.Parameters.Add("@id_cliente", SqlDbType.Int).Value = idCliente;

                    int filas = comando.ExecuteNonQuery();
                    if (filas < 1) respuesta = "No se eliminó ningún registro";
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }

       

        
        


    }
}