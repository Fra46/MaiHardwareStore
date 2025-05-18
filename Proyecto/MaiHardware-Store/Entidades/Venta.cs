using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
    }
}
