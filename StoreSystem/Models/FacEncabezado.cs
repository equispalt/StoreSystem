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
        public int id_pago { get; set; } 
        public int id_moneda { get; set; }  
        public float total_factura { get; set; }


        public List<FacDetalle> lstFacDetalle { get; set; }

        // Otras Referencias
        public string nit_cliente { get; set; }
        public string forma_pago { get; set; }
        public string nombre_moneda { get; set; }
        
    }
}
