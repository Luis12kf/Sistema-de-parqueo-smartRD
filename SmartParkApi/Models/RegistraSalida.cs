using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class RegistraSalida
{
    public int SalidaID { get; set; }

    public int EntradaID { get; set; }

    public DateOnly HoraSalidad {  get; set; }


}
