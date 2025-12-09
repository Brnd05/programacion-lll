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
    public class UMarketDb : DbContext
    {
       
       public UMarketDb(DbContextOptions<UMarketDb> options) : base(options) { }

       public DbSet<Categoria> Categorias { get; set; } 

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Venta> Ventas { get; set; }  
        
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>(equals =>
            {

            });

        }


    }

       
        
    
}

