using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public int EntradaId { get; set; }
        public RegistraEntrada? Entrada { get; set; }
        public int TarifaId { get; set; }
        public Tarifa? Tarifa { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
    }
}
