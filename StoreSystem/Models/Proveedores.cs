using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
{
    public class Proveedores
    {
        public int id_proveedor { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string nombre_proveedor { get; set; }

        [Required(ErrorMessage = "El NIT es requerido")]
        public string nit_proveedor { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        public string telefono_proveedor { get; set; }

        [Required(ErrorMessage = "La Direccion es requerida")]
        public string direccion_proveedor { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        public string correo_proveedor { get; set; }

    }
}
