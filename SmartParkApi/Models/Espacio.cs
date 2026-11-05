using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class Espacio
{
    public int EspacioId { get; set; }

    public int  Numero {  get; set; }

    public int NivelId { get; set; }

    [MaxLength (10)]
    public string? Estado { get; set; }
}
