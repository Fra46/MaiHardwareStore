using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleCotizacion> Detalles { get; set; }
    }
}
