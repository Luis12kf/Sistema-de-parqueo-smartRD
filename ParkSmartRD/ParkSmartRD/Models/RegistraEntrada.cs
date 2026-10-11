using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Models
{
    public class RegistraEntrada
    {
        public int EntradaID { get; set; }

        [Required]
        public int EspacioID { get; set; }

        [Required]
      public DateOnly HoraEntrada { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NombreClinete {  get; set; }

        [Required]
        [MaxLength (50)]
        public string? Placa {  get; set; }

        public bool? Estado { get; set;}
    }
}
