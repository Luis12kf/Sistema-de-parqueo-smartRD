using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Espacio
    {
        public int EspacioId { get; set; }
        public int Numero { get; set; }
        public int NivelId { get; set; }
        public Nivel? Nivel { get; set; }
        public string Estado { get; set; } = "Libre";   // Libre | Ocupado
    }
}
