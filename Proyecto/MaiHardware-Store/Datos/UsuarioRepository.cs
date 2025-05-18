using System.Data.SqlClient;

namespace Datos
{
    public class UsuarioRepository : BaseDatos
    {
        public string AutenticarUsuario(string username, string password)
        {
            AbrirConexion();
            using (var cmd = new SqlCommand("SELECT tipo FROM users WHERE username = @username AND password = @password", Connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                var tipo = cmd.ExecuteScalar() as string;
                CerrarConexion();
                return tipo;
            }
        }
    }
}
