using AcademiaApp.Data;
using AcademiaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaApp.Business
{
    public class CarreraService : ICarrera
    {
        private readonly AcademiaDbContext _db;

        public CarreraService(AcademiaDbContext db)
        {
            _db = db;
        }
        public async Task<int> RegistrarCarrera(string nombre)
        {
            nombre = nombre.Trim();
            var existe = await _db.Carrera.FirstOrDefaultAsync(c => c.Nombre == nombre);
            if (existe is not null)
            {
                return existe.Id;
            }

            var nuevaCarrera = new Carrera {Nombre = nombre};

            _db.Carrera.Add(nuevaCarrera);
            await _db.SaveChangesAsync();

            return nuevaCarrera.Id;
        }

        public async Task<List<Carrera>> ListarCarreraAsync()
        {
            var carreras = await _db.Carrera
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            return carreras;
        }
        
    }
}

