using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CodeFirst.Models
{
    public class AppDb : DbContext
    {
        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Especialidad> Especialidads { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Cita> Cita { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-9C7BQPH\\SQLEXPRESS; Database=ClinicaDb; User Id = sa;" +
                "Password=1234; Trusted_Connection=True; TrustServerCertificate=True;");
        }

    }
}
