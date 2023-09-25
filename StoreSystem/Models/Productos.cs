﻿namespace StoreSystem.Models
{
    public class Productos
    {
        public int id_producto { get; set; } 
        public string nombre_producto { get; set; }
        public string marca_producto { get; set; }
        public string descripcion_producto { get; set; }
        public string estatus_producto { get; set; }
        public string categoria_id { get; set; }
        public string proveedor_id { get; set; }

        //Relacionado a tabla categoria de productos y proveedores
        public string nombre_categoria { get; set; }
        public string nombre_proveedor { get; set; }
    }
}