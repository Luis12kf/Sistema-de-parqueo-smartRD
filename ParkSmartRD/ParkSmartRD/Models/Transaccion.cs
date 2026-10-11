using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Models
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }

        [Required]
        public int EntradaID { get; set; }

        [Required]
        public int TarifaId { get; set; }

        [Required]
        public int UsuarioId {  get; set; }

        [Required]
        public decimal Monto {  get; set; }

        [Required]
        public DateOnly FechaHora { get; set; }
    }
}
