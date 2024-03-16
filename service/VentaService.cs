using System.Linq;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class VentaService
    {
        private CoderContext db;
        public VentaService(CoderContext coderContext)
        {
            this.db = coderContext;

        }
        public  List<Ventum> GetVentas()
            {
               
                    return db.Venta.ToList();
               
            }


            public  List<Ventum> GetVentaById(int id)
            {
                
                    var ventaEncontrada = db.Venta.Where<Ventum>(v => v.Id == id).ToList();
                    return ventaEncontrada.ToList();
                
            }

            public  bool CrearVenta(VentaDto venta, int id)
            {
                
                    var ventaCreada = new Ventum(venta.Comentarios, id);
                    if(ventaCreada != null)
            {

                    db.Venta.Add(ventaCreada);
                    db.SaveChanges();
                return true;
            }
            return false;
                
            }

            public  void UpdateVenta(Ventum venta, int id)
            {
                
                    var ventaAModificar = db.Venta.Where<Ventum>(v => v.Id == id).FirstOrDefault();
                     ventaAModificar.Comentarios = venta.Comentarios;

                    db.Venta.Update(ventaAModificar);
                    db.SaveChanges();
                
            }

        public  bool RemoverVenta(int id)
        {

            var ventaEncontrado = db.Venta.Where<Ventum>(v => v.Id == id).FirstOrDefault();
            if(ventaEncontrado != null)
            {
            db.Remove(ventaEncontrado);
            db.SaveChanges();
                return true;
            }
            return false;

        }
            


        
    }
}
