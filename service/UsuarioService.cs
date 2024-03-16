using WebApiSistemaGestion.database;
using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class UsuarioService
    {
        private CoderContext db;
        public UsuarioService(CoderContext coderContext)
        {
            this.db = coderContext;

        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return this.db.Usuarios.ToList();
        }

        public  List<Usuario> GetUserById(int id)
        {
            
                var usuarioEncontrado = db.Usuarios.Where<Usuario>(u => u.Id == id).ToList();
                return usuarioEncontrado.ToList();
            
        }

        public  bool CrearUsuario(UsuarioDto user)
        {
            
                var usuarioCreado = new Usuario(user.Nombre, user.Apellido, user.NombreUsuario, user.Contraseña, user.Mail);
                 if (usuarioCreado != null)
                     {
                        db.Usuarios.Add(usuarioCreado);
                        db.SaveChanges();
                        return true;
                     }
            return false;


            
        }

        public  bool UpdateUsuario(UsuarioDto user, int id)
        {
            
                var usuarioAModificar = db.Usuarios.Where<Usuario>(u => u.Id == id).FirstOrDefault();
                if(usuarioAModificar != null)
                {
                usuarioAModificar.Nombre = user.Nombre;
                usuarioAModificar.Apellido = user.Apellido;
                usuarioAModificar.NombreUsuario = user.NombreUsuario;
                usuarioAModificar.Contraseña = user.Contraseña;
                usuarioAModificar.Mail = user.Mail;

                db.Usuarios.Update(usuarioAModificar);
                db.SaveChanges();
                return true;

                }
                return false;
            
        }

        public bool RemoveUsuario(int id)
        {

            var usuarioEncontrado = db.Usuarios.Where<Usuario>(u => u.Id == id).FirstOrDefault();
            if(usuarioEncontrado != null)
            {
                db.Remove(usuarioEncontrado);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public  Usuario? ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            List<Usuario> usuarios = db.Usuarios.ToList();



            Usuario? usuarioBuscado = usuarios.Find(u => u.NombreUsuario == usuario && u.Contraseña == password);


            if (usuarioBuscado is null)

            {
                throw new ("Usuario no encontrado");
            }
            return usuarioBuscado;
        }


    }
}
