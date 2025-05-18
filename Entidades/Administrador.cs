namespace Entidades
{
    public class Administrador : Persona
    {
        public string Usuario { get; set; }
        public int Contrasena { get; set; }

        public override string NombreCompleto()
        {
            return $"Admin: {Nombre} {Apellido}";
        }
    }
}
