using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Nivel
    {
        [Key]
        public int NivelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ? Nombre {  get; set; }
        [Required]
        public int Capacidad { get; set; }
    }
}
