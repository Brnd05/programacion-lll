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
    public class D_Categorias
    {
        public DataTable MostrarCategorias()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_MostrarCategorias", SqlCon);
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

        // Agregar dentro de la clase D_Categorias
        public void CargarCombo(ComboBox combo, bool incluirSeleccione = true, string textoSeleccione = "-- Seleccione --")
        {
            try
            {
                DataTable dt = MostrarCategorias(); // usa tu método existente
                if (dt == null) return;

                DataTable dtParaCombo = dt.Copy();

                if (incluirSeleccione)
                {
                    DataRow fila = dtParaCombo.NewRow();
                    fila["id_categoria"] = 0;
                    fila["nombre_categoria"] = textoSeleccione;
                    dtParaCombo.Rows.InsertAt(fila, 0);
                }

                combo.DataSource = dtParaCombo;
                combo.DisplayMember = "nombre_categoria";
                combo.ValueMember = "id_categoria";
                combo.SelectedIndex = 0;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías en ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public string InsertarCategoria(string nombre_categoria)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_InsertarCategoria", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nombre_categoria", SqlDbType.NVarChar, 100).Value = nombre_categoria;

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

        public string ActualizarCategoria(int id_categoria, string nombre_categoria)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_ActualizarCategoria", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_categoria", SqlDbType.Int).Value = id_categoria;
                comando.Parameters.Add("@nombre_categoria", SqlDbType.NVarChar, 100).Value = nombre_categoria;

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

        public string EliminarCategoria(int id_categoria)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("sp_EliminarCategoria", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@id_categoria", SqlDbType.Int).Value = id_categoria;

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
    }
}