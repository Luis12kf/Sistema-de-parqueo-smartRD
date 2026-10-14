using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Tarifa
    {
        public int TarifaId { get; set; }
        public decimal PrimeraHora { get; set; }
        public decimal HoraAdicional { get; set; }
        public decimal TarifaMaximaDiaria { get; set; }
        public DateTime FechaVigenciaDesde { get; set; } = DateTime.Now;
        public bool Activa { get; set; } = true;
    }
}
