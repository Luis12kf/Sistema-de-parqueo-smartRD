using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Models
{
    public class Nivel
    {
        public int NivelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ? Nombre {  get; set; }
        [Required]
        public int Capacidad { get; set; }
    }
}
