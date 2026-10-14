using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Nivel
    {
        public int NivelId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Capacidad { get; set; }
    }
}
