using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.DTO;
namespace UMarket.Application.Contracts
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllAsync();

        Task<ProductoDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(ProductoCreateDto producto);

        Task<bool> UpdateAsync(int id, ProductoUpdateDto dto);

        Task<bool> DeleteAsync(int id);


    }
}
