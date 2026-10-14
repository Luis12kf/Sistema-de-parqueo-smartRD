using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.ComponetModel.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string ContrasenaHash { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Rol { get; set; } = "Cajero";      // Cajero | Administrador
        public bool Activo { get; set; } = true;
    }
}
