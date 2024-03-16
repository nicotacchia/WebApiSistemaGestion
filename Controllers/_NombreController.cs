using Microsoft.AspNetCore.Mvc;

namespace WebApiSistemaGestion.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class _NombreController : Controller
    {
        List<string> list;
        public _NombreController()
        {
            this.list = new List<string>() { "Nicolas Tacchia", "Nico Program", "Nicolas" };
        }
        [HttpGet]
        public string ObtenerNombre()
        {
            return "Nicolas Tacchia";
        }

        [HttpGet("listado")]
        public List<string> ObtenerListadoDeNombres()
        {
            return this.list;
        }

        [HttpGet("listado/{id}")]
        public ActionResult<string> ObtenerNombrePorId(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return BadRequest(new { mensaje = $"El numero no puede ser negativo o mayor que {this.list.Count}", status = 400 });
            }
            return this.list[id];
        }
    }
}
