using SmartManager.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartManager.Data
{
    public class D_VentaDetalle
    {

        public DataTable BuscarVentaDetalle(string cBusqueda = null)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                using (SqlCommand comando = new SqlCommand("dbo.sp_BuscarVentasDetalle", SqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetro @busqueda NVARCHAR(100) del SP
                    var param = comando.Parameters.Add("@busqueda", SqlDbType.NVarChar, 100);
                    param.Value = string.IsNullOrWhiteSpace(cBusqueda) ? (object)DBNull.Value : cBusqueda;

                    SqlCon.Open();
                    Resultado = comando.ExecuteReader(CommandBehavior.CloseConnection);
                    Tabla.Load(Resultado);
                    return Tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (SqlCon != null && SqlCon.State == ConnectionState.Open)
                {
                    try { SqlCon.Close(); } catch {}
                }
            }
        }
        public string InsertarVentaDetalle(int id_venta, int id_producto, int cantidad)
        {
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_InsVentaDetalle", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_venta", SqlDbType.Int).Value = id_venta;
                comando.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;

                SqlCon.Open();
                comando.ExecuteNonQuery();

                return "agregado correctamente.";
            }
            catch (SqlException ex)
            {
                return "Error SQL: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
        }


  
    }
}