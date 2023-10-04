namespace StoreSystem.Models
{
    public class Existencias
    {
        public int id_existencia { get; set; } 
        public string producto_id { get; set; }
        public int cantidad_existencia { get; set; } 
        public DateTime FechaUltimaActualizacion { get; set; }    

    }
}
