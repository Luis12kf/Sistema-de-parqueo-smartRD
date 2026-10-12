using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Tarifa
    {
        [Key]
        public int TarifaId { get; set; }

        [Required]
        public int PrimeraHora { get; set; }

        [Required]
        public int HoraAdicional { get; set; }

        [Required]
        public DateOnly TarifaMaximaDiaria { get; set; }

        public bool Activa { get; set; }
    }
}
