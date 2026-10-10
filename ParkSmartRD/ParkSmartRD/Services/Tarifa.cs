using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Services
{
    public class Tarifa
    {
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
