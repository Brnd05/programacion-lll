using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.Contracts;
using UMarket.Application.DTO;
using UMarket.Application.Interfaces;
using UMarket.Domain.Entities;
using UMarket.Infraestructure.Data;

namespace UMarket.Infraestructure.Services
{
    public class VentaDetalleService : IVentaDetalleService
    {
        private readonly UMarketDb _db;

        public VentaDetalleService(UMarketDb db) => _db = db;   

        public async Task<List<VentaDetalleDto>> GetAllAsync() => await _db.VentasDetalles
            .OrderBy(vd => vd.Id)
            .Select(vd => new VentaDetalleDto
            {
                Id = vd.Id,
                VentaId = vd.VentaId,
                ProductoId = vd.ProductoId,
                Cantidad = vd.Cantidad,
                PrecioUnitario = vd.PrecioUnitario
            }).ToListAsync();

        public async Task<VentaDetalleDto?> GetByIdAsync(int id) => await _db.VentasDetalles
            .Where(vd => vd.Id == id)
            .Select(vd => new VentaDetalleDto
            {
                Id = vd.Id,
                VentaId = vd.VentaId,
                ProductoId = vd.ProductoId,
                Cantidad = vd.Cantidad,
                PrecioUnitario = vd.PrecioUnitario
            })
            .FirstOrDefaultAsync();

        public async Task<List<VentaDetalleDto>> GetByVentaIdAsync(int ventaId) => await _db.VentasDetalles
            .Where(vd => vd.VentaId == ventaId)
            .OrderBy(vd => vd.Id)
            .Select(vd => new VentaDetalleDto
            {
                Id = vd.Id,
                VentaId = vd.VentaId,
                ProductoId = vd.ProductoId,
                Cantidad = vd.Cantidad,
                PrecioUnitario = vd.PrecioUnitario
            }).ToListAsync();


        public async Task<int> CreateAsync(VentaDetalleCreateDto dto)
        {
            var e = new VentaDetalle
            {
                VentaId = dto.VentaId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario
            };
            _db.VentasDetalles.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, VentaDetalleUpdateDto dto)
        {
            var e = await _db.VentasDetalles.FindAsync(id);
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
            var e = await _db.VentasDetalles.FindAsync(id);
            if (e == null) return false;
            _db.VentasDetalles.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
