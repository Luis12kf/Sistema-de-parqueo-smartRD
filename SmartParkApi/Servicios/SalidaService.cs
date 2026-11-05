using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class RegistraSalidaService
{
    private readonly string _connectionString;

    public RegistraSalidaService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // GET: Obtener todas las salidas registradas
    public async Task<IEnumerable<RegistraSalida>> ObtenerTodasAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT SalidaID, EntradaID, HoraSalidad FROM RegistraSalida";
        return await connection.QueryAsync<RegistraSalida>(query);
    }

    // GET: Obtener una salida específica por su ID
    public async Task<RegistraSalida?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT SalidaID, EntradaID, HoraSalidad FROM RegistraSalida WHERE SalidaID = @Id";
        return await connection.QueryFirstOrDefaultAsync<RegistraSalida>(query, new { Id = id });
    }

    // POST: Insertar un nuevo registro de salida
    public async Task<int> CrearAsync(RegistraSalida salida)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            INSERT INTO RegistraSalida (EntradaID, HoraSalidad)
            VALUES (@EntradaID, @HoraSalidad);
            SELECT SCOPE_IDENTITY();"; // Retorna el ID generado automáticamente

        var nuevoId = await connection.ExecuteScalarAsync<int>(query, salida);
        return nuevoId;
    }
}