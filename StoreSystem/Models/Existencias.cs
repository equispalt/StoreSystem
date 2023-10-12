namespace StoreSystem.Models
{
    public class Existencias
    {
        public int id_existencia { get; set; }
        public int producto_id { get; set; }
        public int cantidad_existencia { get; set; }
        public int precio_id { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }

        // campos relacionados para mostrar datos
   
        public string nombre_producto { get; set; }
        public string descripcion_producto  { get; set; }
        public float precio_unidad { get; set; }
        public string nombre_categoria  { get; set; }
        public string nombre_proveedor  { get; set; }
 
    }
}
