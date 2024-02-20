using System;
using System.Collections.Generic;

namespace WebApiSistemaGestion.models
{
    public partial class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido(int stock, int idProducto, int idVenta)
        {
      
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Ventum IdVentaNavigation { get; set; } = null!;
    }
}
