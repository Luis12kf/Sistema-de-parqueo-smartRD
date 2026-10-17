using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class RegistraEntradaService
{
    private readonly string _connectionString;

    public RegistraEntradaService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // GET: Obtener todas las entradas
    public async Task<IEnumerable<RegistraEntrada>> ObtenerTodasAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT EntradaID, EspacioID, HoraEntrada, NombreCliente, Placa, Estado FROM RegistraEntrada";
        return await connection.QueryAsync<RegistraEntrada>(query);
    }

    // GET: Obtener una entrada por ID
    public async Task<RegistraEntrada?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT EntradaID, EspacioID, HoraEntrada, NombreCliente, Placa, Estado FROM RegistraEntrada WHERE EntradaID = @Id";
        return await connection.QueryFirstOrDefaultAsync<RegistraEntrada>(query, new { Id = id });
    }

    // POST: Insertar un nuevo registro de entrada
    public async Task<int> CrearAsync(RegistraEntrada entrada)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            INSERT INTO RegistraEntrada (EspacioID, HoraEntrada, NombreCliente, Placa, Estado)
            VALUES (@EspacioID, @HoraEntrada, @NombreCliente, @Placa, @Estado);
            SELECT SCOPE_IDENTITY();"; // Retorna el ID generado automáticamente

        // Ejecutamos y obtenemos el ID del nuevo registro
        var nuevoId = await connection.ExecuteScalarAsync<int>(query, entrada);
        return nuevoId;
    }
}