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
    public class D_Venta
    {
        public string InsertarVenta(int id_vendedor, int id_cliente, out int id_venta)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            id_venta = 0;

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_InsertarVenta", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_vendedor", SqlDbType.Int).Value = id_vendedor;
                comando.Parameters.Add("@id_cliente", SqlDbType.Int).Value = id_cliente;

                SqlParameter parIdVenta = new SqlParameter("@id_venta", SqlDbType.Int);
                parIdVenta.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdVenta);

                SqlCon.Open();
                int filas = comando.ExecuteNonQuery();

                if (comando.Parameters["@id_venta"].Value != DBNull.Value)
                {
                    id_venta = Convert.ToInt32(comando.Parameters["@id_venta"].Value);
                }

                return "Inserción exitosa.";
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

            public DataTable MostrarVentas()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_MostrarVentas", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                SqlCon.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);

                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
        }
    }
}