using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Transaccion
    {
        [Key]
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
