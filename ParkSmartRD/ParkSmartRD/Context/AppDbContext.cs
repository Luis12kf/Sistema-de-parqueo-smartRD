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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nivel>().ToTable("Nivel");
            modelBuilder.Entity<Espacio>().ToTable("Espacio");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Tarifa>().ToTable("Tarifa");
            modelBuilder.Entity<Transaccion>().ToTable("Transaccion");

            modelBuilder.Entity<RegistraEntrada>(e =>
            {
                e.ToTable("RegistraEntrada");
                e.HasKey(x => x.EntradaId);
            });

            modelBuilder.Entity<RegistraSalida>(e =>
            {
                e.ToTable("RegistraSalida");
                e.HasKey(x => x.SalidaId);
                e.Property(x => x.HoraSalida).HasColumnName("HoraSalidad");
            });
        }

    }


}
