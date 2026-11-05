using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartParkApi.Models;

public class Usuario
{
    public int UsuarioID { get; set; }

    [MaxLength(50)]
    public string ? NombreUsuario { get; set; }

    [MaxLength(100)]
    public string ? NombreCompleto { get; set; }

    [MaxLength(256)]
    public string ? ContrasenaHash {  get; set; }

    [MaxLength(20)]
    public string ? Rol {  get; set; }

    public bool Activo {  get; set; }
}
