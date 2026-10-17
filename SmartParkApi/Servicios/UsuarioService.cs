using Dapper;
using Microsoft.Data.SqlClient;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class UsuarioService(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    // GET: Obtener todos los usuarios
    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT UsuarioID, NombreUsuario, NombreCompleto, ContrasenaHash, Rol, Activo FROM Usuario";
        return await connection.QueryAsync<Usuario>(query);
    }

    // GET: Obtener un usuario por su ID
    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT UsuarioID, NombreUsuario, NombreCompleto, ContrasenaHash, Rol, Activo FROM Usuario WHERE UsuarioID = @Id";
        return await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
    }
}