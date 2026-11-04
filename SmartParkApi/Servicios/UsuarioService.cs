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
        var query = "SELECT UsuarioID, NombreUsuario, ContrasenaHash, NombreCompleto, Rol, Activo FROM Usuario";
        var usuarios = (await connection.QueryAsync<Usuario>(query)).ToList();

        // Si la tabla está completamente vacía, creamos un usuario inicial por defecto
        if (!usuarios.Any())
        {
            try
            {
                var seedQuery = @"
                    INSERT INTO Usuario (NombreUsuario, ContrasenaHash, NombreCompleto, Rol, Activo)
                    VALUES ('admin', 'admin123', 'Administrador General', 'Admin', 1);
                    SELECT UsuarioID, NombreUsuario, ContrasenaHash, NombreCompleto, Rol, Activo FROM Usuario;";
                usuarios = (await connection.QueryAsync<Usuario>(seedQuery)).ToList();
            }
            catch
            {
                // Si la inserción automática no procede por esquema, retornamos la lista vacía
            }
        }

        return usuarios;
    }

    // GET: Obtener un usuario por su ID
    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = "SELECT UsuarioID, NombreUsuario, ContrasenaHash, NombreCompleto, Rol, Activo FROM Usuario WHERE UsuarioID = @Id";
        return await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
    }

    // POST: Crear nuevo usuario
    public async Task<int> CrearAsync(Usuario usuario)
    {
        using var connection = new SqlConnection(_connectionString);
        var query = @"
            INSERT INTO Usuario (NombreUsuario, ContrasenaHash, NombreCompleto, Rol, Activo)
            VALUES (@NombreUsuario, @ContrasenaHash, @NombreCompleto, @Rol, @Activo);
            SELECT SCOPE_IDENTITY();";
        return await connection.ExecuteScalarAsync<int>(query, usuario);
    }
}
