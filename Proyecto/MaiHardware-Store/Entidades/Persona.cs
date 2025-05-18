namespace Entidades
{
    public abstract class Persona
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public uint Telefono { get; set; }
        public string Correo { get; set; }
        public string Tipo { get; set; }

        public abstract string NombreCompleto();
    }
}
