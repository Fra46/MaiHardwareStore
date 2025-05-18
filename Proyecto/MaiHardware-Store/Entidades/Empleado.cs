namespace Entidades
{
    public class Empleado : Persona
    {

        public string Usuario { get; set; }
        public int Contrasena { get; set; }
        public string Cargo { get; set; }
        public double Sueldo { get; set; }

        public override string NombreCompleto()
        {
            return $"Empleado: {Nombre} {Apellido}";
        }
    }
}
