using Dapper;
using Microsoft.Data.SqlClient;
using ParkSmartRD.Models;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class TransaccionService(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    // GET: Obtener todas las transacciones
    public async Task<IEnumerable<Transaccion>> ObtenerTodasAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT TransaccionId, EntradaID, TarifaId, UsuarioId, Monto, FechaHora FROM Transaccion";
        return await connection.QueryAsync<Transaccion>(query);
    }

    // GET: Obtener una transacción por su ID
    public async Task<Transaccion?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT TransaccionId, EntradaID, TarifaId, UsuarioId, Monto, FechaHora FROM Transaccion WHERE TransaccionId = @Id";
        return await connection.QueryFirstOrDefaultAsync<Transaccion>(query, new { Id = id });
    }

    // POST: Insertar una nueva transacción
    public async Task<int> CrearAsync(Transaccion transaccion)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            INSERT INTO Transaccion (EntradaID, TarifaId, UsuarioId, Monto, FechaHora)
            VALUES (@EntradaID, @TarifaId, @UsuarioId, @Monto, @FechaHora);
            SELECT SCOPE_IDENTITY();";

        var nuevoId = await connection.ExecuteScalarAsync<int>(query, transaccion);
        return nuevoId;
    }

    // PUT: Actualizar una transacción existente
    public async Task<bool> ActualizarAsync(Transaccion transaccion)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            UPDATE Transacciones 
            SET EntradaID = @EntradaID,
                TarifaId = @TarifaId,
                UsuarioId = @UsuarioId,
                Monto = @Monto,
                FechaHora = @FechaHora
            WHERE TransaccionId = @TransaccionId";

        var filasAfectadas = await connection.ExecuteAsync(query, transaccion);
        return filasAfectadas > 0;
    }

    // general reportes
    public async Task<IEnumerable<TransaccionReporteDto>> ObtenerReporteAsync(DateTime inicio, DateTime fin)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
        SELECT 
            t.TransaccionId,
            t.FechaHora,
            ISNULL(e.Placa, 'S/P') AS Placa,
            ISNULL(DATEDIFF(MINUTE, e.HoraEntrada, ISNULL(s.HoraSalidad, t.FechaHora)), 0) AS MinutosEstadia,
            t.Monto
        FROM Transaccion t
        INNER JOIN RegistraEntrada e ON t.EntradaID = e.EntradaID
        LEFT JOIN RegistraSalida s ON t.EntradaID = s.EntradaID
        WHERE CAST(t.FechaHora AS DATE) BETWEEN @Inicio AND @Fin
        ORDER BY t.FechaHora DESC";
        return await connection.QueryAsync<TransaccionReporteDto>(query, new
        {
            Inicio = inicio.Date,
            Fin = fin.Date
        });

    }
}