using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Reporte
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<Producto> ProductosMasVendidos { get; set; }
    }
}
