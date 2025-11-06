using Microsoft.EntityFrameworkCore;
using AcademiaApp.Models;

namespace AcademiaApp.Data
{
    public class AcademiaDbContext : DbContext
    {

        public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options) : base(options)
        {
        }

        public DbSet<Carrera> Carrera => Set<Carrera>();
        public DbSet<Estudiante> Estudiante => Set<Estudiante>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Carrera>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

         modelBuilder.Entity<Estudiante>()
               .Property(e => e.Nombre)
               .IsRequired()
               .HasMaxLength(100);

        modelBuilder.Entity<Estudiante>()
                .Property(e => e.Carnet)
                .IsRequired();

        modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Carrera)
                .WithMany(c => c.Estudiantes)
                .HasForeignKey(e => e.CarreraId);

        }
    }
}
