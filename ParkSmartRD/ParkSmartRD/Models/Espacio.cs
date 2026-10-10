using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Models
{
    public class Espacio
    {
        public int EspacioId { get; set; }

        [Required]
        public int  Numero {  get; set; }

        [Required]
        public int NivelId { get; set; }

        [MaxLength(10)]
        public string? Estado { get; set; }
    }
}
