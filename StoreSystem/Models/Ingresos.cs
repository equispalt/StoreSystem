using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
{
	public class Ingresos
	{
		public int id_ingreso { get; set; }
		public string compra_id { get; set; }

        [Required(ErrorMessage = "El campo cantidad ingreso es obligatorio.")]
        public int producto_id { get; set; }

        [Required(ErrorMessage = "El campo cantidad ingreso es obligatorio.")]
        public int cantidad_ingreso { get; set; }

        [Required(ErrorMessage = "El campo costo de ingreso es obligatorio.")]
        public float costo_ingreso { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Vencimiento es obligatorio.")]
        public DateTime fecha_vencimiento { get; set; }

		public string comentario_ingreso { get; set; }

        // ingreso de parametros automaticos
        public DateTime fecha_ingreso { get; set; }
		public int usuario_id { get; set; }



		//Relacionado a tabla de productos
		public int id_producto { get; set; }
		public string nombre_producto { get; set; }

        public string correoUsr {  get; set; }  
	}
}
