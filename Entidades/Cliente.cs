using System;

namespace Entidades
{
    public class Cliente : Persona
    {
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }

        public override string NombreCompleto()
        {
            return $"Sr/a: {Nombre} {Apellido}";
        }
    }
}
