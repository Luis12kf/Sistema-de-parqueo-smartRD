using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Models
{
    public class RegistraSalida
    {
        public int SalidaID { get; set; }

        public int EntradaID { get; set; }

        [Required]
        public DateOnly HoraSalidad {  get; set; }


    }
}
