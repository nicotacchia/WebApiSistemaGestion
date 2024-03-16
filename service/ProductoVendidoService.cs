using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class ProductoVendidoService
    {
        private CoderContext db;
        public ProductoVendidoService(CoderContext coderContext)
        {
            this.db = coderContext;

        }

        public  List<ProductoVendido> GetProductosVendidos()
        {
                return db.ProductoVendidos.ToList();
        }


        public  List<ProductoVendido> GetProductVendidoById(int id)
        {
                var productoEncontrado = db.ProductoVendidos.Where<ProductoVendido>(p => p.Id == id).ToList();
                return productoEncontrado.ToList();
            
        }

        public  void CrearProducto(ProductoVendido producto, Ventum venta, Producto prd)
        {
           
                var productoCreado = new ProductoVendido(producto.Stock, prd.Id, venta.Id);
                db.ProductoVendidos.Add(productoCreado);
                db.SaveChanges();
        }

    }
}
