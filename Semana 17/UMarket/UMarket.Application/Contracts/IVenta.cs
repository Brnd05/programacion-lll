using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.DTO;
namespace UMarket.Application.Contracts
{
    public interface IVenta
    {
        Task<List<VentaDto>> GetAllAsync();

        Task<VentaDto?> GetByIdAsync(Guid id);

        Task<int> CreateAsync(VentaCreateDto venta);

        Task<int> UpdateAsync(int id, VentaUpdateDto dto);

        Task<bool> DeleteAsync(int id);

    }
}
