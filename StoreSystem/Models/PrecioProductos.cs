using NuGet.Protocol.Plugins;

namespace StoreSystem.Models
{
    public class PrecioProductos
    {
        public int id_precio { get; set; }
        public int producto_id { get; set; }
        public float precio_unidad { get; set; }
        public DateTime fecha_vigencia { get; set; }
        public DateTime fecha_configuracion { get; set; }
        public int usuario_id { get; set; }
        public int estado { get; set; }

        //Relacionado a otras tabla
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string correoUsr { get; set; }

    }
}
