using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.Models
{
    public class RegistraEntrada
    {
        [Key]
        public int EntradaID { get; set; }

        [Required]
        public int EspacioID { get; set; }

        [Required]
      public DateTime HoraEntrada { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NombreClinete {  get; set; }

        [Required]
        [MaxLength (50)]
        public string? Placa {  get; set; }

        public bool? Estado { get; set;}
    }
}
