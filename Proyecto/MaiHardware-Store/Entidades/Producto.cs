namespace Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Codigo: {Codigo}, Nombre: {Nombre}, Categoria: {Categoria}, Descripcion: {Descripcion}, Precio: {Precio}, Stock: {Stock}";
        }
    }
}
