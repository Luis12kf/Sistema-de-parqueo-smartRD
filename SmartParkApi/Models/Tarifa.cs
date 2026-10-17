using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class Tarifa
{
    public int TarifaId { get; set; }

    public Decimal PrimeraHora { get; set; }

    public Decimal HoraAdicional { get; set; }

    public Decimal TarifaMaximaDiaria { get; set; }

    public DateOnly FechaVigenciaDesde { get; set; }

    public bool Activa { get; set; }
}
