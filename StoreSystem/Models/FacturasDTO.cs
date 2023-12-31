﻿using System.Security.Principal;

namespace StoreSystem.Models
{
    public class FacturasDTO
    {
        // encabezado
        public int id_factura { get; set; }
        public DateTime fecha_factura { get; set; }
        public string estado_factura { get; set; }
        public int cliente_id { get; set; }
        public int usuario_id { get; set; }
        public int id_pago { get; set; } 
        public int id_moneda { get; set; } 
        public float total_factura { get; set; }

        // referencias
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string nit_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string nombre_moneda { get; set; }
        public string forma_pago { get; set; }


        // detalle
        public int id_detalle { get; set; }
        public int factura_id { get; set; }
        public int producto_id { get; set; }
        public float cantidad_detalle { get; set; } 
        public float precio_detalle { get; set; } 
        public float subtotal_detalle { get; set; }    
        
        //referencias
        public string descripcion_producto { get; set; }




    }
}
