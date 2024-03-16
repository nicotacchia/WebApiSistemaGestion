using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.service;
using System.Collections.Generic;
using WebApiSistemaGestion.Dtos;

namespace WebApiSistemaGestion.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class _VentaController : Controller
    {
        private VentaService ventaService;

        public _VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("TraerVentas")]

        public List<Ventum> GetVenta()
        {
            return ventaService.GetVentas();
        }

        [HttpDelete("EliminarVenta/{id}")]

        public IActionResult DeleteVentaxId(int id)
        {
            if (ventaService.RemoverVenta(id))
            {
                return base.Ok(new { mensaje = "Venta removido", status = 200 });
            }
            return BadRequest(new {mensaje = "No se encontro la venta", status = 400});
        }

        [HttpPost]
        public IActionResult CargarVenta([FromBody] VentaDto venta, int Id)
        {

            if (this.ventaService.CrearVenta(venta, Id))
            {

                return base.Ok(new { mensaje = "Venta Creada", venta });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se cargo la venta" });
            }
        }
    }
}
