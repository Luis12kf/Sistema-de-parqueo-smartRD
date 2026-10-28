namespace ParkSmartRD.Models;

public class TransaccionReporteDto
{
    public int TransaccionId { get; set; }
    public DateTime FechaHora { get; set; }
    public string Placa { get; set; } = string.Empty;
    public double MinutosEstadia { get; set; }
    public decimal Monto { get; set; }
}
