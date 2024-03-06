using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.service;


namespace WebApiSistemaGestion.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class _ProductoController : Controller
    {
        private ProductoService productoService;
        public _ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }
        [HttpPost]
            public IActionResult CrearUnNuevoProducto([FromBody] ProductoDto producto)
        {

            if (this.productoService.CrearProducto(producto))
            {

                return base.Ok(new { mensaje = "Producto Creado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se creo un producto" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarProducto(int id)
        {
            if (id > 0)
            {
                if (this.productoService.RemoveProduct(id))
                {
                    return base.Ok(new { mensaje = "Producto removido", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo remover el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProductoPorId(int id, ProductoDto productoDTO)
        {
            if (id > 0)
            {
                if (this.productoService.UpdateProducto( productoDTO, id))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", status = 200, productoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo actualizar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

    }
}
