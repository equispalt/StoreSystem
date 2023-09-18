using System.ComponentModel.DataAnnotations;

namespace StoreSystem.Models
{
    public class Usuarios
    {
        public int idUsr { get; set; }

        public string nombreUsr { get; set; }

        public string apellidoUsr { get; set; }
        
        public string correoUsr { get; set; }

        public string passwordUsr { get; set; }

        public string ConfirmarClave { get; set; }
    }
}
