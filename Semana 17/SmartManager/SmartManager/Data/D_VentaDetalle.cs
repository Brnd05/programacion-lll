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
    public class D_VentaDetalle
    {
        public DataTable ListarVentaDetalle(string cBusquedaVentaDetalle)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_VentaDetalle", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("cBusquedaVentaDetalle", SqlDbType.VarChar).Value = cBusquedaVentaDetalle;
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

        public string InsertarVentaDetalle(int id_venta, int id_producto, int cantidad, decimal precio_unitario)
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
                comando.Parameters.Add("@precio_unitario", SqlDbType.SmallMoney).Value = precio_unitario;

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                return filas > 0 ? "Inserción de detalle de venta exitosa." : "No se insertó ningún detalle de venta.";
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