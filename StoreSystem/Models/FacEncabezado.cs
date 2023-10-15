using System.Security.Principal;

namespace StoreSystem.Models
{
    public class FacEncabezado
    {
        public int id_factura { get; set; }
        public DateTime fecha_factura { get; set; }
        public string estado_factura { get; set; }
        public int cliente_id { get; set; }
        public int usuario_id { get; set; }
        public float total_factura { get; set; }
);
    }
}
