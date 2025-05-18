namespace Entidades
{
    public class DetalleCotizacion
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
