using SmartManager.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartManager.Data
{
    public class D_Productos
    {
        public string InsertarProducto(string nombre_producto, int id_categoria, decimal precio_producto, int existencias_producto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_InsertarProducto", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nombre_producto", SqlDbType.NVarChar, 250).Value = nombre_producto;
                comando.Parameters.Add("@id_categoria", SqlDbType.Int).Value = id_categoria;
                comando.Parameters.Add("@precio_producto", SqlDbType.SmallMoney).Value = precio_producto;
                comando.Parameters.Add("@existencias_producto", SqlDbType.Int).Value = existencias_producto;

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                return filas > 0 ? "Inserción exitosa." : "No se insertó ningún registro.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string ActualizarProducto(int id_producto, string nombre_producto, int id_categoria, decimal precio_producto, int existencias_producto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_ActualizarProducto", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
                comando.Parameters.Add("@nombre_producto", SqlDbType.NVarChar, 250).Value = nombre_producto;
                comando.Parameters.Add("@id_categoria", SqlDbType.Int).Value = id_categoria;
                comando.Parameters.Add("@precio_producto", SqlDbType.SmallMoney).Value = precio_producto;
                comando.Parameters.Add("@existencias_producto", SqlDbType.Int).Value = existencias_producto;

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                return filas > 0 ? "Actualización exitosa." : "No se actualizó ningún registro.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string EliminarProducto(int id_producto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_EliminarProducto", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                return filas > 0 ? "Eliminación exitosa." : "No se eliminó ningún registro.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public DataTable MostrarProductos()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_MostrarProductos", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                SqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }
    }
}