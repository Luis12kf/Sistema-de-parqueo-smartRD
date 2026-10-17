using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class NivelService
{
    private readonly string _connectionString;

    public NivelService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // GET: Obtener todos los niveles
    public async Task<IEnumerable<Nivel>> ObtenerTodosAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT NivelId, Nombre, Capacidad FROM Nivel";
        return await connection.QueryAsync<Nivel>(query);
    }

    // GET: Obtener un nivel por su Id
    public async Task<Nivel?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT NivelId, Nombre, Capacidad FROM Nivel WHERE NivelId = @Id";
        return await connection.QueryFirstOrDefaultAsync<Nivel>(query, new { Id = id });
    }
}