
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartManager.Data
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        //Constructor privado para implementar el patrón Singleton
        private Conexion()
        {
            //Inicializar los valores de conexión
            this.Servidor = "DESKTOP-9C7BQPH\\SQLEXPRESS";
            this.Base = "SmartManagerDb";
            this.Usuario = "sa";
            this.Clave = "1234";
        }
        //Método estático para obtener la instancia única de la clase Conexion
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                          ";Database=" + this.Base +
                                          ";User Id=" + this.Usuario +
                                          ";Password=" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        public static Conexion crearInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }

    }
}
