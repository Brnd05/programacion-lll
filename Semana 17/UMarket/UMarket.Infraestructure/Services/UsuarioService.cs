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
     public class UsuarioService
    {
        private readonly UMarketDb _db;
        public UsuarioService(UMarketDb db) => _db = db;
        public async Task<List<UsuarioDto>> GetAllAsync() => await _db.Usuarios
            .OrderBy(u => u.Nombre)
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Contraseña = u.Contraseña,
                Rol = u.Rol
            }).ToListAsync();
        public async Task<UsuarioDto?> GetByIdAsync(int id) => await _db.Usuarios
            .Where(u => u.Id == id)
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Contraseña = u.Contraseña,
                Rol = u.Rol
            })
            .FirstOrDefaultAsync();
        public async Task<int> CreateAsync(UsuarioCreateDto dto)
        {
            var e = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                Rol = dto.Rol
            };
            _db.Usuarios.Add(e);
            await _db.SaveChangesAsync();
            return e.Id;

        }

        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            var e = await _db.Usuarios.FindAsync(id);
            if (e == null) return false;
            e.Nombre = dto.Nombre;
            e.Correo = dto.Correo;
            e.Contraseña = dto.Contraseña;
            e.Rol = dto.Rol;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _db.Usuarios.FindAsync(id);
            if (e == null) return false;
            _db.Usuarios.Remove(e);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
