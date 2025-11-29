using Microsoft.EntityFrameworkCore;
using PizzaUNAB.Domain.Entities;

namespace PizzaUNAB.Infrastructure.Data
{
    public class PizzeriaDb : DbContext
    {
        public PizzeriaDb(DbContextOptions<PizzeriaDb> options) : base(options) { }

        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoItem> PedidoItems => Set<PedidoItem>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Pizza>(e =>
            {
                e.Property(p => p.Nombre).HasMaxLength(150).IsRequired();
                e.Property(p => p.Precio).HasPrecision(10, 2);
                e.Property(p => p.Stock).HasDefaultValue(0);
            });

            mb.Entity<Cliente>(e =>
            {
                e.Property(p => p.Nombre).HasMaxLength(150).IsRequired();
                e.Property(p => p.Telefono).HasMaxLength(20);
            });

            mb.Entity<Pedido>(e =>
            {
                e.Property(p => p.Total).HasPrecision(12, 2);
                e.HasOne(p => p.Cliente)
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(p => p.ClienteId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<PedidoItem>(e =>
            {
                e.Property(p => p.PrecioUnitario).HasPrecision(10, 2);
                e.Property(p => p.Subtotal).HasPrecision(12, 2);
                e.HasOne(pi => pi.Pizza).WithMany(p => p.Items)
                  .HasForeignKey(pi => pi.PizzaId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
