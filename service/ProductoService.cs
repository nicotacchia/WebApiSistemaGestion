using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class ProductoService
    {

        public static List<Producto> GetProductos()
        {
            using (CoderContext db = new CoderContext())
            {
                return db.Productos.ToList();
            }
        }


        public static List<Producto> GetProductById(int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoEncontrado = db.Productos.Where<Producto>(p => p.Id == id).ToList();
                return productoEncontrado.ToList();
            }
        }

        public static void CrearProducto(Producto producto)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoCreado = new Producto(producto.Descripciones,producto.Costo,producto.PrecioVenta,producto.Stock);
                db.Productos.Add(productoCreado);
                db.SaveChanges();


            }
        }

        public static void UpdateUsuario(Producto prod, int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoAModificar = db.Productos.Where<Producto>(p => p.Id == id).FirstOrDefault();
                
                productoAModificar.Descripciones = prod.Descripciones;
                productoAModificar.Costo = prod.Costo;
                productoAModificar.PrecioVenta = prod.PrecioVenta;
                productoAModificar.Stock = prod.Stock;

                db.Productos.Update(productoAModificar);
                db.SaveChanges();
            }
        }

        public static void RemoveProduct(int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoEncontrado = db.Productos.Where<Producto>(p => p.Id == id).FirstOrDefault();
                db.Remove(productoEncontrado);
                db.SaveChanges();
            }
        }
    }
}
