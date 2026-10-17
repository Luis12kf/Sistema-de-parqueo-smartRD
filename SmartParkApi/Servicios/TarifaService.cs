using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class TarifaService
{
    private readonly string _connectionString;

    public TarifaService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // GET: Obtener todas las tarifas
    public async Task<IEnumerable<Tarifa>> ObtenerTodasAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT TarifaId, PrimeraHora, HoraAdicional, TarifaMaximaDiaria, FechaVigenciaDesde,Activa FROM Tarifa";
        return await connection.QueryAsync<Tarifa>(query);
    }

    // GET: Obtener una tarifa específica por su ID
    public async Task<Tarifa?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT TarifaId, PrimeraHora, HoraAdicional, TarifaMaximaDiaria, Activa FROM Tarifa WHERE TarifaId = @Id";
        return await connection.QueryFirstOrDefaultAsync<Tarifa>(query, new { Id = id });
    }

    // POST: Insertar una nueva tarifa
    public async Task<int> CrearAsync(Tarifa tarifa)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            INSERT INTO Tarifa (PrimeraHora, HoraAdicional, TarifaMaximaDiaria, Activa)
            VALUES (@PrimeraHora, @HoraAdicional, @TarifaMaximaDiaria, @Activa);
            SELECT SCOPE_IDENTITY();"; // Retorna el ID generado

        var nuevoId = await connection.ExecuteScalarAsync<int>(query, tarifa);
        return nuevoId;
    }

    // PUT: Actualizar una tarifa existente
    public async Task<bool> ActualizarAsync(Tarifa tarifa)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            UPDATE Tarifa 
            SET PrimeraHora = @PrimeraHora,
                HoraAdicional = @HoraAdicional,
                TarifaMaximaDiaria = @TarifaMaximaDiaria,
                Activa = @Activa
            WHERE TarifaId = @TarifaId";

        var filasAfectadas = await connection.ExecuteAsync(query, tarifa);
        return filasAfectadas > 0;
    }
}
