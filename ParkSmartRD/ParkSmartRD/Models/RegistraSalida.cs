using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkSmartRD.ComponetModel.Models
{
    public class RegistraSalida
    {
        [Key]
        public int SalidaID { get; set; }

        public int EntradaID { get; set; }

        [Required]
        public DateOnly HoraSalidad {  get; set; }


    }
}
