using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.Mappers
{
    public class UsuarioMapper
    {

        public static Usuario MapearAProducto(UsuarioDto dto)
        {
            Usuario user = new Usuario();
            user.Id = dto.Id;
            user.Nombre = dto.Nombre;
            user.Apellido = dto.Apellido;
            user.NombreUsuario = dto.NombreUsuario;
            user.Contraseña = dto.Contraseña;
            user.Mail = dto.Mail;
            return user;
        }
    }
}
