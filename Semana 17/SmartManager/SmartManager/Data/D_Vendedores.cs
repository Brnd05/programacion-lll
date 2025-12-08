using SmartManager.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartManager.Data
{
    public class D_Vendedores
    {
        public DataTable MostrarVendedores()
        {
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = null;
            SqlDataReader resultado = null;

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand("sp_MostrarVendedores", sqlCon))
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

    }
}

