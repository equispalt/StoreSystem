using System.ComponentModel.DataAnnotations;


namespace StoreSystem.Models
{
    public class Clientes
    {
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string nombre_cliente { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string apellido_cliente { get; set; }

        [Required(ErrorMessage = "El DPI es requerido")]
        public string dpi_cliente { get; set; }

        [Required(ErrorMessage = "El NIT es requerido")]
        public string nit_cliente { get; set; }

        [Required]
        public string telefono_cliente { get; set; }

        [Required]
        public string direccion_cliente { get; set; }

        [Required]
        public string correo_cliente { get; set; }


    }
}
