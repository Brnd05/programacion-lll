using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.Contracts;
using UMarket.Application.DTO;
using UMarket.Domain.Entities;
using UMarket.Infraestructure.Data;

namespace UMarket.Infraestructure.Services
{
    public class VentaService
    {
        private readonly UMarketDb _db;

        public VentaService(UMarketDb db) => _db = db;

        public async Task<List<VentaDto>> GetAllAsync() => await _db.Ventas
            .OrderBy(v => v.Fecha)
            .Select(v => new VentaDto
            {
                Id = v.Id,
                UsuarioId = v.UsuarioId,
                Fecha = v.Fecha,
                Total = v.Total
            }).ToListAsync();
        public async Task<VentaDto?> GetByIdAsync(int id) => await _db.Ventas
            .Where(v => v.Id == id)
            .Select(v => new VentaDto
            {
                Id = v.Id,
                UsuarioId = v.UsuarioId,
                Fecha = v.Fecha,
                Total = v.Total
            })
            .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(VentaCreateDto dto)
        {
            var e = new Venta
            {
                UsuarioId = dto.UsuarioId,
                Fecha = dto.Fecha,
                Total = dto.Total
            };
            _db.Ventas.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, VentaUpdateDto dto)
        {
            var e = await _db.Ventas.FindAsync(id);
            if (e == null) return false;
            e.UsuarioId = dto.UsuarioId;
            e.Fecha = dto.Fecha;
            e.Total = dto.Total;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Ventas.FindAsync(id);
            if (e == null) return false;
            _db.Ventas.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
