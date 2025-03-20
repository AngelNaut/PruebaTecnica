using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Interfaces;
using PruebaTecnica.Models;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _productoService;

        public ProductoController(IProducto productoService)
        {
            _productoService = productoService;
        }
        [HttpPost("crear")]
        public IActionResult CreateProduct([FromBody] Producto producto) {

            _productoService.SaveProduct(producto);
            return Ok(producto);
        }

        [HttpGet("listaProductos")]
        public IActionResult GetProducts(int id) {
            IEnumerable<Producto> products = _productoService.GetProducts();
            return Ok(products);
        }

        [HttpGet("obtener/{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _productoService.GetProducto(id);
            return Ok(producto);
        }

        [HttpPut("editar/{id}")]
        public IActionResult EditProducto(int id, [FromBody]Producto producto) 
        {
            if (producto == null || producto.ProductoId != id)
            {
                return BadRequest("El producto es nulo o el Id no coincide.");
            }

            var existingProduct = _productoService.GetProducto(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productoService.UpdateProduct(producto.ProductoId, producto);
            return Ok(producto);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult DeleteProducto(int id) {
            var product = _productoService.GetProducto(id);
            if (product == null)
            {
                return NotFound();
            }

            _productoService.DeleteProduct(id);
            return NoContent(); // Retorna 204 No Content
        }
    }
}
