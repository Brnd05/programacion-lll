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
    public class VentaDetalleService
    {
        private readonly UMarketDb _db;

        public VentaDetalleService(UMarketDb db) => _db = db;   

        public async Task<List<VentaDetalleDto>> GetAllAsync() => await _db.VentaDetalles
            .OrderBy(vd => vd.Id)
            .Select(vd => new VentaDetalleDto
            {
                Id = vd.Id,
                VentaId = vd.VentaId,
                ProductoId = vd.ProductoId,
                Cantidad = vd.Cantidad,
                PrecioUnitario = vd.PrecioUnitario
            }).ToListAsync();

        public async Task<VentaDetalle?> GetByIdAsync(int id) => await _db.VentaDetalles
            .Where(vd => vd.Id == id)
            .Select(vd => new VentaDetalle
            {
                Id = vd.Id,
                VentaId = vd.VentaId,
                ProductoId = vd.ProductoId,
                Cantidad = vd.Cantidad,
                PrecioUnitario = vd.PrecioUnitario
            })
            .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(VentaDetalleCreateDto dto)
        {
            var e = new VentaDetalle
            {
                VentaId = dto.VentaId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario
            };
            _db.VentaDetalles.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, VentaDetalleUpdateDto dto)
        {
            var e = await _db.VentaDetalles.FindAsync(id);
            if (e == null) return false;
            e.VentaId = dto.VentaId;
            e.ProductoId = dto.ProductoId;
            e.Cantidad = dto.Cantidad;
            e.PrecioUnitario = dto.PrecioUnitario;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.VentaDetalles.FindAsync(id);
            if (e == null) return false;
            _db.VentaDetalles.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
