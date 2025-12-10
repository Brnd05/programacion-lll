using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using UMarket.Domain.Entities;

namespace UMarket.Infraestructure.Data
{
    using System.Reflection.Emit;
    using Microsoft.EntityFrameworkCore;

    public class UMarketDb : DbContext
    {
        public UMarketDb(DbContextOptions<UMarketDb> options) : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();   
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<VentaDetalle> VentaDetalles => Set<VentaDetalle>();

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Categoria>(e =>
            {         
                e.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);
                e.HasMany(c => c.Productos)
                      .WithOne(p => p.Categoria)
                      .HasForeignKey(p => p.CategoriaId)
                      .OnDelete(DeleteBehavior.Cascade);//Si se borra una categoria se borran todos los productos de ella D:
            });

            mb.Entity<Producto>(e =>
            {
                
                e.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(p => p.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300);

                e.Property(p => p.Precio)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                e.Property(p => p.Stock)
                    .IsRequired();

                
                e.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Cascade);
                
            });

            mb.Entity<Usuario>(e =>
            {

                e.Property(u => u.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(u => u.Correo)
                    .IsRequired()
                    .HasMaxLength(150);
                e.Property(u => u.Contraseña)
                    .IsRequired()
                    .HasMaxLength(200);
                e.Property(u => u.Rol)
                    .IsRequired()
                    .HasConversion<int>();
            });

            mb.Entity<Venta>(e =>
            {
  
                e.Property(v => v.Fecha)
                    .IsRequired();

                e.Property(v => v.Total)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

               
                e.HasOne(v => v.Usuario)
                    .WithMany() 
                    .HasForeignKey(v => v.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

              
                e.HasMany(v => v.Detalles)
                    .WithOne(d => d.Venta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.Cascade);
               
            });

            mb.Entity<VentaDetalle>(e =>
            {
    
                e.Property(d => d.Cantidad)
                    .IsRequired();
                e.Property(d => d.PrecioUnitario)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                e.HasOne(d => d.Venta)
                    .WithMany(v => v.Detalles)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(d => d.Producto)
                    .WithMany() 
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
               
            });





        }
    }




}

