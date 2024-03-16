using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class _ProductoVendidoController : Controller
    {

        private ProductoVendidoService prodVendido;

        public _ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.prodVendido = productoVendidoService;
        }

        [HttpGet("Productos/{id}")]
        public List<ProductoVendido> ObtenerProductosVendidosPorIdUsuario(int id)
        {
            return prodVendido.GetProductVendidoById(id);
        }
    }
}
