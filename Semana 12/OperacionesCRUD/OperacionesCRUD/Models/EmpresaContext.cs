using Microsoft.EntityFrameworkCore;

namespace OperacionesCRUD.Models
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Departamento> Departamentos  { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-9C7BQPH\\SQLEXPRESS; " +
            "Database=OperacionesCRUD;" +
            " User Id=sa; Password=1234; Trusted_Connection=True;" +
            " TrustServerCertificate=True;");
        }
    }
}
