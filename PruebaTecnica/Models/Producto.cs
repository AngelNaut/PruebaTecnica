namespace PruebaTecnica.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}
