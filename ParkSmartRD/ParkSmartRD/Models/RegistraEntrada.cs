using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class RegistraEntrada
    {
        public int EntradaId { get; set; }
        public int EspacioId { get; set; }
        public Espacio? Espacio { get; set; }
        public DateTime HoraEntrada { get; set; } = DateTime.Now;
        public string? NombreCliente { get; set; }
        public string Placa { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;          // true = el vehículo sigue dentro
    }
}
