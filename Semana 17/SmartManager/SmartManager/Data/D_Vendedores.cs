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

        public bool Login(string usuario, string contraseña)
        {
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = null;
            SqlDataReader resultado = null;

            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                sqlCon.Open();

                using (SqlCommand comando = new SqlCommand("sp_IniciarSesion", sqlCon))
                {
                    comando.CommandType = CommandType.StoredProcedure; // corrected variable name
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    resultado = comando.ExecuteReader();
                    tabla.Load(resultado); 

                    if (tabla.Rows.Count > 0)
                    {
                        
                        SmartManager frm = new SmartManager();
                        frm.Show();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (resultado != null && !resultado.IsClosed)
                    resultado.Close();

                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }





    }
}

