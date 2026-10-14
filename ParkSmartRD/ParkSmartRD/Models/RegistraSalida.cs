using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class RegistraSalida
    {
        public int SalidaId { get; set; }
        public int? EntradaId { get; set; }
        public RegistraEntrada? Entrada { get; set; }
        public DateTime HoraSalida { get; set; } = DateTime.Now;   // columna: HoraSalidad
    }

}
