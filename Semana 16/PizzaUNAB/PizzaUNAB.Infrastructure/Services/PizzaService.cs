using Microsoft.EntityFrameworkCore;
using PizzaUNAB.Application.Contracts;
using PizzaUNAB.Application.DTOs;
using PizzaUNAB.Domain.Entities;
using PizzaUNAB.Infrastructure.Data;

namespace PizzaUNAB.Infrastructure.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzeriaDb _db;
        public PizzaService(PizzeriaDb db) => _db = db;

        public async Task<List<PizzaDto>> GetAllAsync() =>
            await _db.Pizzas
                .OrderBy(p => p.Nombre)
                .Select(p => new PizzaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .ToListAsync();

        public async Task<PizzaDto?> GetByIdAsync(int id) =>
            await _db.Pizzas
                .Where(p => p.Id == id)
                .Select(p => new PizzaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(PizzaCreateDto dto)
        {
            var e = new Pizza
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            _db.Pizzas.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, PizzaUpdateDto dto)
        {
            var e = await _db.Pizzas.FindAsync(id);
            if (e is null) return false;

            e.Nombre = dto.Nombre;
            e.Precio = dto.Precio;
            e.Stock = dto.Stock;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Pizzas.FindAsync(id);
            if (e is null) return false;
            _db.Pizzas.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
