using EmpresaApp.Data;
using EmpresaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Business
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly EmpresaDbContext _db;

        public DepartamentoService(EmpresaDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ActualizarDepartamentoAsync(int id, string nuevoNombre)
        {
            var departamento = await _db.Departamento.FindAsync(id);
            if (departamento is null) return false;

            departamento.Nombre = nuevoNombre;
            await _db.SaveChangesAsync();
            return true; 
        }

        public async Task<int> CrearDepartamentoAsync(string nombre)
        {
            nombre = nombre.Trim();
            var existe = await _db.Departamento.FirstOrDefaultAsync(d => d.Nombre == nombre);
            if (existe is not null) {
                return existe.Id;
            }

            var nuevoDepartamento = new Departamento {Nombre = nombre};

            _db.Departamento.Add(nuevoDepartamento);
            await _db.SaveChangesAsync();

            return nuevoDepartamento.Id;
        }

        public async Task<bool> EliminarDepartamentosAsync(int id)
        {
            var departamento = await _db.Departamento
                .Include(d => d.Nombre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (departamento is null) return false;
            if (departamento.Empleados.Any()) return false;

            _db.Departamento.Remove(departamento);
            await _db.SaveChangesAsync();

            return true;

        

        }

        public async Task<List<Departamento>> ListarDepartamentosAsync()
        {
            var departamentos = await _db.Departamento
                .OrderBy(d => d.Nombre)
                .ToListAsync();

            return departamentos;
               

        }
    }
}
