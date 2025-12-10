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
     public class ProductoService
    {
        private readonly UMarketDb _db;

        public ProductoService(UMarketDb db) => _db = db;

        public async Task<List<ProductoDto>> GetAllAsync() => await _db.Productos
            .OrderBy(p => p.Nombre)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                CategoriaId = p.CategoriaId,
                Stock = p.Stock
            }).ToListAsync();

        public async Task<ProductoDto?> GetByIdAsync(int id) => await _db.Productos
            .Where(p => p.Id == id)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                CategoriaId = p.CategoriaId,
                Stock = p.Stock
            })
            .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(ProductoCreateDto dto)
        {
            var e = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                CategoriaId = dto.CategoriaId,
                Stock = dto.Stock
            };
            _db.Productos.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

        public async Task<bool> UpdateAsync(int id, ProductoUpdateDto dto) 
        {
            var e = await _db.Productos.FindAsync(id);
            if (e is null) return false;

            e.Nombre = dto.Nombre;
            e.Descripcion = dto.Descripcion;
            e.Precio = dto.Precio;
            e.CategoriaId = dto.CategoriaId;
            e.Stock = dto.Stock;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Productos.FindAsync(id);
            if (e is null) return false;
            _db.Productos.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
