using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.models;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class _UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public _UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this.usuarioService.ObtenerTodosLosUsuarios();
        }
    }
}
