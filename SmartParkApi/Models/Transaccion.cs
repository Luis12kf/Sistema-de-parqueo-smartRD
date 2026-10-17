using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkApi.Models;

public class Transaccion
{
    public int TransaccionId { get; set; }

    public int EntradaID { get; set; }

    public int TarifaId { get; set; }

    public int UsuarioId {  get; set; }

    public decimal Monto {  get; set; }

    public DateOnly FechaHora { get; set; }
}
