using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class Nivel
{
    public int NivelId { get; set; }

    [MaxLength(50)]
    public string ? Nombre {  get; set; }

    public int Capacidad { get; set; }
}
