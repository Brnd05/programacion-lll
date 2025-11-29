using Microsoft.EntityFrameworkCore;
using PizzaUNAB.Application.Contracts;
using PizzaUNAB.Application.DTOs;
using PizzaUNAB.Domain.Entities;
using PizzaUNAB.Infrastructure.Data;

namespace PizzaUNAB.Infrastructure.Services
{
    public class ClienteService : IClienteService
    {
        private readonly PizzeriaDb _db;
        public ClienteService(PizzeriaDb db) => _db = db; 

        public async Task<List<ClienteDto>> GetAllAsync() =>
            await _db.Clientes
                .OrderBy(c => c.Nombre)
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono
                })
                .ToListAsync();

        public async Task<ClienteDto?> GetByIdAsync(int id) =>
            await _db.Clientes
                .Where(c => c.Id == id)
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(ClienteCreateDto dto)
        {
            var e = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono
            };
            _db.Clientes.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, ClienteUpdateDto dto)
        {
            var e = await _db.Clientes.FindAsync(id);
            if (e is null) return false;

            e.Nombre = dto.Nombre;
            e.Telefono = dto.Telefono;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Clientes.FindAsync(id);
            if (e is null) return false;

            _db.Clientes.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
