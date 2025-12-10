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
    public class CategoriaService : ICategoriaService
    {
        private readonly UMarketDb _db;

        public CategoriaService(UMarketDb db) => _db = db;

        public async Task<List<CategoriaDto>> GetAllAsync() => await _db.Categorias
            .OrderBy(c => c.Nombre)
            .Select(c => new CategoriaDto


            {


                Id = c.Id,
                Nombre = c.Nombre,
                Productos = c.Productos.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    CategoriaId = p.CategoriaId,
                    Stock = p.Stock
                }).ToList()



            }).ToListAsync();

        public async Task<CategoriaDto?> GetByIdAsync(int id) => await _db.Categorias
            .Where(c => c.Id == id)
            .Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Productos = c.Productos.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    CategoriaId = p.CategoriaId,
                    Stock = p.Stock
                }).ToList()
            })
            .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(CategoriaCreateDto dto)
        {
            var e = new Categoria
            {
                Nombre = dto.Nombre
            };
            _db.Categorias.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;
        }

         public async Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto) { 
            var e = await _db.Categorias.FindAsync(id);
            if (e is null) return false;

            e.Nombre = dto.Nombre;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Categorias.FindAsync(id);
            if (e is null) return false;
            _db.Categorias.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
