using System.Linq.Expressions;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.Mappers;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.service
{
    public class ProductoService
    {

        private CoderContext db;

        public ProductoService(CoderContext coderContext)
        {
            this.db = coderContext;
        }

        public  List<Producto> GetProductById(int id)
        {
            
                var productoEncontrado = db.Productos.Where<Producto>(p => p.Id == id).ToList();
                return productoEncontrado.ToList();
            
        }

        public List<Producto> GetAllProducts()
        {
            return db.Productos.ToList();
        }

        public bool CrearProducto(ProductoDto producto)
        {
            Producto productoCreado = ProductoMapper.MapearAProducto(producto);
                db.Productos.Add(productoCreado);
                db.SaveChanges();
                return true;

        }

        public bool UpdateProducto(ProductoDto prod, int id)
        {
         
                var productoAModificar = this.db.Productos.Where<Producto>(p => p.Id == id).FirstOrDefault();
                if(productoAModificar != null)
                {
                    productoAModificar.Descripciones = prod.Descripciones;
                    productoAModificar.Costo = prod.Costo;
                    productoAModificar.PrecioVenta = prod.PrecioVenta;
                    productoAModificar.Stock = prod.Stock;

                    db.Productos.Update(productoAModificar);
                    db.SaveChanges();
                    return true;
                }
                return false;
                
            
        }

        public  bool RemoveProduct(int id)
        {
            
                var productoEncontrado = db.Productos.Where<Producto>(p => p.Id == id).FirstOrDefault();
                
                if (productoEncontrado != null)
                {
                    db.Remove(productoEncontrado);
                    db.SaveChanges();
                    return true;
                }
                return false;
             
            
        }
    }
}
