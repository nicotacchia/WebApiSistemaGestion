using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using WebApiSistemaGestion.Dtos;
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

        [HttpGet("UsuarioXId/{id}")]
        public ActionResult<List<Usuario>> ObtenerUsuarioPorId(int id)
        {
            if (id < 0)
            {
                return BadRequest(new { mensaje = $"El numero no puede ser negativo", status = 400 });
            }
            return this.usuarioService.GetUserById(id);
        }

        [HttpDelete("PorId/{id}")]
        public IActionResult BorrarUsuario(int id)
        {
            if (id > 0)
            {
                if (this.usuarioService.RemoveUsuario(id))
                {
                    return base.Ok(new { mensaje = "Usuario removido", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo remover el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPut("PorId/{id}")]
        public IActionResult ModificarUsuario(UsuarioDto user, int id)
        {
            if (id > 0)
            {
                if (this.usuarioService.UpdateUsuario(user, id))
                {
                    return base.Ok(new { mensaje = "Usuario Actualizado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo actualizar el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

        [HttpPost("Crear/")]
        public IActionResult CrearUsuario(UsuarioDto user)
        {
           
                if (this.usuarioService.CrearUsuario(user))
                {
                    return base.Ok(new { mensaje = "Usuario creado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo crear el usuario" });


         
        }


        [HttpGet("{usuario}/{password}")]

        public ActionResult<Usuario> ObtenerUsuarioPorNombreYPassword(string usuario, string password)
        {
            try
            {

                return usuarioService.ObtenerUsuarioPorUsuarioYPassword(usuario, password);
            }
            catch (DataBaseException ex)
            {
                return base.Conflict(new { error = ex.Message, status = HttpStatusCode.InternalServerError });
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return base.Conflict(new { error = ex.Message, status = HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return base.Conflict(new { error = ex.Message, status = HttpStatusCode.Conflict });
            }


        }

        [Serializable]
        private class DataBaseException : Exception
        {
            public DataBaseException()
            {
            }

            public DataBaseException(string? message) : base(message)
            {
            }

            public DataBaseException(string? message, Exception? innerException) : base(message, innerException)
            {
            }

            protected DataBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }

    [Serializable]
    internal class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException()
        {
        }

        public UsuarioNoEncontradoException(string? message) : base(message)
        {
        }

        public UsuarioNoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioNoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
