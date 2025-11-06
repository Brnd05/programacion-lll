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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly EmpresaDbContext _db;

        public EmpleadoService(EmpresaDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ActualizarEmpleadoAsync(int id,string nombre, decimal salario, int departamentoId)
        {
            var empleado = await _db.Empleados.FindAsync(id);

            if (empleado is null) return false;

            empleado.Nombre = nombre;
            empleado.Salario = salario;
            empleado.DepartamentoId = departamentoId;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task AgregarEmpleadoAsync(string nombre, decimal salario, int departamentoId)
        {
            _db.Empleados.Add(new Empleado
            {
                Nombre = nombre,
                Salario = salario,
                DepartamentoId = departamentoId
            });

             await _db.SaveChangesAsync();
        }

        public async Task<bool> EliminarEmpleadoAsync(int id)
        {
            var empleado = await _db.Empleados.FindAsync(id);

            if(empleado is null) return false;

            _db.Remove(empleado);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Empleado>> ListarEmpleadoAsync()
        {
            var empleados = await _db.Empleados.OrderBy(x=>x.Nombre)
                .ToListAsync();

            return empleados;
        }
    }
}
