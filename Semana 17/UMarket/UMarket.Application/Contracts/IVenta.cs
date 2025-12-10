using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UMarket.Application.DTO;

namespace UMarket.Application.Interfaces
{
    public interface IVentaService
    {   
        Task<List<VentaDto>> GetAllAsync();
        Task<VentaDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(VentaCreateDto dto);
        Task<bool> UpdateAsync(int id, VentaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<VentaDetalleDto>> GetDetallesByVentaIdAsync(int ventaId);
        Task<int> AddDetalleAsync(int ventaId, VentaDetalleCreateDto dto);
        Task<bool> UpdateDetalleAsync(int detalleId, VentaDetalleUpdateDto dto);
        Task<bool> DeleteDetalleAsync(int detalleId);
    }
}