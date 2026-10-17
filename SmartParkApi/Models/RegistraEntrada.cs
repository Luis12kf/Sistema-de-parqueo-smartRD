using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class RegistraEntrada
{
   
    public int EntradaID { get; set; }

    public int EspacioID { get; set; }

  public DateOnly HoraEntrada { get; set; }

    [MaxLength(100)]
    public string? NombreCliente {  get; set; }

    [MaxLength (50)]
    public string? Placa {  get; set; }

    public bool? Estado { get; set;}
}
