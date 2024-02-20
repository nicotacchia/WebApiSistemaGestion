using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class ProductoVendidoService
    {

        public static List<ProductoVendido> GetProductosVendidos()
        {
            using (CoderContext db = new CoderContext())
            {
                return db.ProductoVendidos.ToList();
            }
        }


        public static List<ProductoVendido> GetProductVendidoById(int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoEncontrado = db.ProductoVendidos.Where<ProductoVendido>(p => p.Id == id).ToList();
                return productoEncontrado.ToList();
            }
        }

        public static void CrearProducto(ProductoVendido producto, Ventum venta, Producto prd)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoCreado = new ProductoVendido(producto.Stock, prd.Id, venta.Id);
                db.ProductoVendidos.Add(productoCreado);
                db.SaveChanges();


            }
        }

        public static void UpdateUsuario(ProductoVendido prod, int id)
        {
            using (CoderContext db = new CoderContext())
            {
                var productoAModificar = db.ProductoVendidos.Where<ProductoVendido>(p => p.Id == id).FirstOrDefault();

                productoAModificar.Stock = prod.Stock;
                productoAModificar.IdProducto = prod.IdProducto;
                productoAModificar.IdVenta = prod.IdVenta;
                

                db.ProductoVendidos.Update(productoAModificar);
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
