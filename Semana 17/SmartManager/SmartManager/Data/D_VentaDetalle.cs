using SmartManager.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartManager.Data
{
    public class D_VentaDetalle
    {
        /// <summary>
        /// Ejecuta el procedimiento almacenado dbo.sp_BuscarVentasDetalle.
        /// Si cBusqueda es null o vacío devuelve todos los registros.
        /// Devuelve un DataTable con las columnas tal como las retorna el SP.
        /// </summary>
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
                    try { SqlCon.Close(); } catch { /* ignorar */ }
                }
            }
        }
        public string InsertarVentaDetalle(int id_venta, int id_producto, int cantidad)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_InsertarVentaDetalle", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_venta", SqlDbType.Int).Value = id_venta;
                comando.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
                comando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                return filas > 0 ? "Detalle de venta insertado correctamente." : "No se insertó ningún detalle de venta.";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
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


        /// <summary>
        /// Inserta un detalle de venta usando el procedimiento sp_InsertarVentaDetalle.
        /// Devuelve mensaje indicando resultado.
        /// </summary>

    }
}