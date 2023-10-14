using System.Security.Policy;

namespace StoreSystem.Models
{
    public class Caja
    {
        public int id_caja { get; set; }
        public float MontoInicial { get; set; }
        public DateTime fecha_apertura { get; set; }
        public DateTime? fecha_cierre { get; set; }
        public string estado_caja { get; set; }
        public int usuario_id { get; set; }

        //relacionado a otras tablas
        public string correoUsr { get; set; }

    }
}
