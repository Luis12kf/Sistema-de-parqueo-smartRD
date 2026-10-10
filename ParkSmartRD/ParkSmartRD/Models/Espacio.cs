using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Services
{
    public class Espacio
    {
        public int EspacioId { get; set; }

        [Required]
        public int  Numero {  get; set; }

        [Required]
        public int NivelId { get; set; }

        [MaxLength(10)]
        public String? Estado { get; set; }
    }
}
