using WebApiSistemaGestion.database;
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

        public  void CrearUsuario( Usuario user)
        {
            
                var usuarioCreado = new Usuario(user.Nombre, user.Apellido, user.NombreUsuario, user.Contraseña, user.Mail);
                db.Usuarios.Add(usuarioCreado);
                db.SaveChanges();   


            
        }

        public  void UpdateUsuario(Usuario user, int id)
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


    }
}
