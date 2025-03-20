using PruebaTecnica.Context;
using PruebaTecnica.Interfaces;
using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public class ProductoService : IProducto
    {
        private readonly PruebaTecnicaContext _pruebaTecnicaContext;
        public ProductoService(PruebaTecnicaContext pruebaTecnicaContext)
        {
            _pruebaTecnicaContext = pruebaTecnicaContext;
        }
        public void DeleteProduct(int id)
        {
            var buscarproducto = _pruebaTecnicaContext.Productos.Find(id);
            if (buscarproducto != null) { 
                _pruebaTecnicaContext.Productos.Remove(buscarproducto);
                _pruebaTecnicaContext.SaveChanges();
            }
        }

        public Producto GetProducto(int id)
        {
            return _pruebaTecnicaContext.Productos.Find(id); ;
        }

        public IEnumerable<Producto> GetProducts()
        {
            return _pruebaTecnicaContext.Productos.ToList();
        }

        public void SaveProduct(Producto producto)
        {
            producto.FechaCreacion =  DateTime.Now;
            _pruebaTecnicaContext.Productos.Add(producto);
            _pruebaTecnicaContext.SaveChanges ();
        }

        public void UpdateProduct(int id, Producto producto)
        {
            var buscarproducto = _pruebaTecnicaContext.Productos.Find(id);
            if (buscarproducto != null)
            {
                buscarproducto.Nombre = producto.Nombre;
                buscarproducto.Precio = producto.Precio;
                buscarproducto.FechaCreacion = producto.FechaCreacion;
                _pruebaTecnicaContext.SaveChanges();
            }

        }
    }
}
