using Datos;

namespace Logica
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository = new UsuarioRepository();

        public string Autenticar(string username, string password)
        {
            return usuarioRepository.AutenticarUsuario(username, password);
        }
    }
}
