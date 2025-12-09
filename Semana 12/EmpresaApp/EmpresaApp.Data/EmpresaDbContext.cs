using EmpresaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresaApp.Data
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options) : base(options)
        { 
        }

        public DbSet<Departamento> Departamento => Set<Departamento>();
        public DbSet<Empleado> Empleados => Set<Empleado>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>()
            .Property(d => d.Nombre)
            .HasMaxLength(100)
            .IsRequired();

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasColumnType("decimal(12,2)");

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.DepartamentoId);
                
        }
    }
}
