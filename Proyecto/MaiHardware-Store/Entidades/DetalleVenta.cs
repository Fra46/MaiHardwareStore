namespace Entidades
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
