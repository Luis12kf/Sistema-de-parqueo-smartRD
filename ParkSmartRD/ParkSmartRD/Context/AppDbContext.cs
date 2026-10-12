using Microsoft.EntityFrameworkCore;
using ParkSmartRD.ComponetModel.Models;

namespace ParkSmartRD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        //Se necesita apregar las entidades de modelos
        public DbSet<Espacio> Espacios { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<RegistraEntrada> RegistraEntradas { get; set; }
        public DbSet<RegistraSalida> RegistraSalidas { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
