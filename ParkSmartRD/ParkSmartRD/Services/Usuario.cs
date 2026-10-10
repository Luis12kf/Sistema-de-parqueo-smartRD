using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkSmartRD.Services
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ? NombreUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string ? NombreCompleto { get; set; }

        [Required]
        [MaxLength(256)]
        public string ? ContrasenaHash {  get; set; }

        [Required]
        [MaxLength(20)]
        public string ? Rol {  get; set; }

        public bool Activo {  get; set; }
    }
}
