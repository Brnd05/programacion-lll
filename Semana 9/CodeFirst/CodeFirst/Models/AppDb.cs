using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class AppDb : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server =DESKTOP-9C7BQPH\\SQLEXPRESS; " +
            "Database=MiTiendaCodeFirstDb;" +
            " User Id=sa; Password=1234; Trusted_Connection=True;" +
            " TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Tecnologia" },
                new Categoria { Id = 2, Nombre = "Hogar" },
                new Categoria { Id = 3, Nombre = "Alimentos"}
                );


            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop", Precio = 999.99m, CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Mouse", Precio = 20.5m, CategoriaId = 1},
                new Producto { Id = 3, Nombre = "Silla", Precio = 120, CategoriaId = 2}
                );  
        }
    }
}