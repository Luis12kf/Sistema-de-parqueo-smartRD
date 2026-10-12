using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Espacio
    {
        [Key]
        public int EspacioId { get; set; }

        [Required]
        public int  Numero {  get; set; }

        [Required]
        public int NivelId { get; set; }

        [MaxLength(10)]
        public string? Estado { get; set; }
    }
}
