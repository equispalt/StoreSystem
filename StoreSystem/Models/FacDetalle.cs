using System.Security.Principal;

namespace StoreSystem.Models
{
    public class FacDetalle
    {
        public int id_detalle {  get; set; }   
        public int factura_id { get; set; }
        public int producto_id { get; set; }    
        public float cantidad_detalle { get; set; }
        public int precio_id { get; set; }  
        public float precio_detalle { get; set; }
        public float subtotal_detalle { get; set; }
    }
}
