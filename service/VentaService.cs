using System.Linq;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class VentaService
    {
        
            public static List<Ventum> GetVentas()
            {
                using (CoderContext db = new CoderContext())
                {
                    return db.Venta.ToList();
                }
            }


            public static List<Ventum> GetUserById(int id)
            {
                using (CoderContext db = new CoderContext())
                {
                    var ventaEncontrada = db.Venta.Where<Ventum>(v => v.Id == id).ToList();
                    return ventaEncontrada.ToList();
                }
            }

            public static void CrearVenta(Ventum venta, Usuario user)
            {
                using (CoderContext db = new CoderContext())
                {
                    var ventaCreada = new Ventum(venta.Comentarios,user.Id);
                    db.Venta.Add(ventaCreada);
                    db.SaveChanges();


                }
            }

            public static void UpdateVenta(Ventum venta, int id)
            {
                using (CoderContext db = new CoderContext())
                {
                    var ventaAModificar = db.Venta.Where<Ventum>(v => v.Id == id).FirstOrDefault();
                     ventaAModificar.Comentarios = venta.Comentarios;

                    db.Venta.Update(ventaAModificar);
                    db.SaveChanges();
                }
            }

            public static void RemoveUsuario(int id)
            {
                using (CoderContext db = new CoderContext())
                {
                    var ventaEncontrado = db.Venta.Where<Ventum>(v => v.Id == id).FirstOrDefault();
                    db.Remove(ventaEncontrado);
                    db.SaveChanges();
                }
            }


        
    }
}
