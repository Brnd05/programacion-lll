using Microsoft.EntityFrameworkCore;
namespace IntroduccionEF
{
    public class AppDb : DbContext
    {
        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
