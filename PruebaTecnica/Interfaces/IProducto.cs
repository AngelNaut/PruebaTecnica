using PruebaTecnica.Models;

namespace PruebaTecnica.Interfaces
{
    public interface IProducto
    {
        public void SaveProduct(Producto producto);
        Producto GetProducto(int id);
        IEnumerable<Producto> GetProducts();
        public void UpdateProduct(int id , Producto producto);
        public void DeleteProduct(int id);
    }
}
