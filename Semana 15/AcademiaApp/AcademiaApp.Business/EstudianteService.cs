using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiaApp.Data;
using AcademiaApp.Models;
using Microsoft.EntityFrameworkCore;
namespace AcademiaApp.Business
{
    public class EstudianteService : IEstudiante
    {
        private readonly AcademiaDbContext _db;

        public EstudianteService(AcademiaDbContext db)
        {
            _db = db;
        }

        public async Task AgregarEstudianteAsync(string nombre, string carnet, int carreraId)
        {
            _db.Estudiante.Add(new Estudiante
            {
                Nombre = nombre,
                Carnet = carnet,
                CarreraId = carreraId
            });

            await _db.SaveChangesAsync();
        }

        public async Task <List<Estudiante>> ListarEstudianteAsync()
        {
           var estudiantes = await _db.Estudiante.OrderBy(x =>x.Nombre ).ToListAsync();

            return estudiantes;
        }
    }
}
