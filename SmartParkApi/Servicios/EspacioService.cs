using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class EspacioService(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    // Método GET para obtener todos los espacios
    public async Task<IEnumerable<Espacio>> ObtenerTodosAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT EspacioId, Numero, NivelId, Estado FROM Espacio";
        return await connection.QueryAsync<Espacio>(query);
    }

    // Método GET para obtener un espacio por su Id
    public async Task<Espacio?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT EspacioId, Numero, NivelId, Estado FROM Espacios WHERE EspacioId = @Id";
        return await connection.QueryFirstOrDefaultAsync<Espacio>(query, new { Id = id });
    }
public async Task<bool> ActualizarAsync(Espacio espacio)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"
            UPDATE Espacios 
            SET Numero = @Numero,
                NivelId = @NivelId,
                Estado = @Estado
            WHERE EspacioId = @EspacioId";

        var filasAfectadas = await connection.ExecuteAsync(query, espacio);

        // Retorna true si se actualizó al menos una fila, de lo contrario false
        return filasAfectadas > 0;
    }
}
  

