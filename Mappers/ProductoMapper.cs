using WebApiSistemaGestion.Dtos;
using WebApiSistemaGestion.models;

namespace WebApiSistemaGestion.Mappers
{
    public static class ProductoMapper
    {
       
            public static Producto MapearAProducto(ProductoDto dto)
            {
                Producto producto = new Producto();
                producto.Descripciones = dto.Descripciones;
                producto.Id = dto.Id;
                producto.PrecioVenta = dto.PrecioVenta;
                producto.Stock = dto.Stock;
                producto.Costo = dto.Costo;
                producto.IdUsuario = dto.IdUsuario;
                return producto;
            }

            public static ProductoDto MapearADTO(Producto producto)
            {
                ProductoDto dto = new ProductoDto();

                dto.Descripciones = producto.Descripciones;
                dto.Id = producto.Id;
                dto.PrecioVenta = producto.PrecioVenta;
                dto.Stock = producto.Stock;
                dto.Costo = producto.Costo;
                dto.IdUsuario = producto.IdUsuario;

                return dto;

            }
        }
}
