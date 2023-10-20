using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
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
        public int id_categoria { get; set; }
        public string nombre_categoria { get; set; }
        public int id_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        [Required(ErrorMessage = "El campo precio es obligatorio")]
        [Range(0.0, float.MaxValue, ErrorMessage ="El valor es invalido")]
        public float precio_unidad { get; set; }    

    }
}
            