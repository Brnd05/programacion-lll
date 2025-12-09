using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.DTO;
namespace UMarket.Application.Contracts
{
    public interface IVentaDetalle
    {
        Task<List<VentaDetalleDto>> GetAllAsync();
        Task<VentaDetalleDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(VentaDetalleCreateDto ventaDetalle);
        Task<int> UpdateAsync(int id, VentaDetalleUpdateDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
