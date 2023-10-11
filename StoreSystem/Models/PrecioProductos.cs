using NuGet.Protocol.Plugins;

namespace StoreSystem.Models
{
    public class PrecioProductos
    {
        public int id_precio { get; set; }
        public int producto_id { get; set; }
        public float precio_unidad { get; set; }
        public int producto_gratuito {get; set;}
        public int segundo_producto_descuento { get; set; }
        public int cantidad_mayoreo { get; set; }
        public DateOnly fecha_modificacion_precio { get; set; }

    }
}
