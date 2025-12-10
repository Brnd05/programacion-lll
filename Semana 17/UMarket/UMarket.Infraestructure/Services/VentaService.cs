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
using UMarket.Application.Interfaces;

namespace UMarket.Infraestructure.Services
{
    public class VentaService : IVentaService
    {
        private readonly UMarketDb _db;

        public VentaService(UMarketDb db) => _db = db;

       public async Task<List<VentaDto>> GetAllAsync() => await _db.Ventas
            .OrderBy(v => v.Id)
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

        public async Task<List<VentaDetalleDto>> GetDetallesByVentaIdAsync(int ventaId) => await _db.VentasDetalles
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

        public async Task<int> AddDetalleAsync(int ventaId, VentaDetalleCreateDto dto)
        {
            var e = new VentaDetalle
            {
                VentaId = ventaId,
                ProductoId = dto.ProductoId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario
            };
            _db.VentasDetalles.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateDetalleAsync(int detalleId, VentaDetalleUpdateDto dto)
        {
            var e = await _db.VentasDetalles.FindAsync(detalleId);
            if (e == null) return false;
            e.VentaId = dto.VentaId;
            e.ProductoId = dto.ProductoId;
            e.Cantidad = dto.Cantidad;
            e.PrecioUnitario = dto.PrecioUnitario;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDetalleAsync(int detalleId)
        {
            var e = await _db.VentasDetalles.FindAsync(detalleId);
            if (e == null) return false;
            _db.VentasDetalles.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
