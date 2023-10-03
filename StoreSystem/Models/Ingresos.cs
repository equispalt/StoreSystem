using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
{
	public class Ingresos
	{
		public int id_ingreso { get; set; }
		public int producto_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        [Required(ErrorMessage = "El campo cantidad ingreso es obligatorio.")]
        public int cantidad_ingreso { get; set; }

        [Required(ErrorMessage = "El campo costo de ingreso es obligatorio.")]
        [Range(0, float.MaxValue, ErrorMessage = "La cantidad = o mayor a 0.")]
        public float costo_ingreso { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Vencimiento es obligatorio.")]
        public DateOnly fecha_vencimiento { get; set; }
		public DateTime fecha_ingreso { get; set; }
		public int usuario_id { get; set; }

		//Relacionado a tabla de productos
		public int id_producto { get; set; }
		public string nombre_producto { get; set; }

	}
}
