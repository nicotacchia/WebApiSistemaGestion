using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public static class UsuarioService
    {
        public static List<Usuario> GetUsuarios()
        {
            using (CoderContext db = new CoderContext())
            {
                return db.Usuarios.ToList();
            }
        }


        public static List<Usuario> GetUserById(int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var usuarioEncontrado = db.Usuarios.Where<Usuario>(u => u.Id == id).ToList();
                return usuarioEncontrado.ToList();
            }
        }

        public static void CrearUsuario( Usuario user)
        {
            using (CoderContext db = new CoderContext())
            {
                var usuarioCreado = new Usuario(user.Nombre, user.Apellido, user.NombreUsuario, user.Contraseña, user.Mail);
                db.Usuarios.Add(usuarioCreado);
                db.SaveChanges();   


            }
        }

        public static void UpdateUsuario(Usuario user, int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var usuarioAModificar = db.Usuarios.Where<Usuario>(u => u.Id == id).FirstOrDefault();
                usuarioAModificar.Nombre = user.Nombre;
                usuarioAModificar.Apellido = user.Apellido;
                usuarioAModificar.NombreUsuario = user.NombreUsuario;
                usuarioAModificar.Contraseña = user.Contraseña;
                usuarioAModificar.Mail = user.Mail;

                db.Usuarios.Update(usuarioAModificar);
                db.SaveChanges();
            }
        }

        public static void RemoveUsuario(int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var usuarioEncontrado = db.Usuarios.Where<Usuario>(u => u.Id == id).FirstOrDefault();
                db.Remove(usuarioEncontrado);
                db.SaveChanges();
            }
        }


    }
}
