using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class BaseDatos
    {
        protected string ConnectionString = "Server=.\\SQLEXPRESS;Database=MaiHardware_StoreDB;User Id=admin;Password=admin123";
        protected SqlConnection Connection;

        public BaseDatos()
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public ConnectionState AbrirConexion()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                Connection.Open();
                return Connection.State;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                Console.WriteLine($"Número de error: {ex.Number}");

                if (ex.Number == 18456)
                {
                    Console.WriteLine("Error de autenticación. Verifica usuario y contraseña.");
                }
                else if (ex.Number == 4060)
                {
                    Console.WriteLine("No se pudo acceder a la base de datos especificada.");
                }
                throw;
            }
        }

        public void CerrarConexion()
        {
            Connection.Close();
        }

        public bool TestConexion()
        {
            try
            {
                AbrirConexion();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
