using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.DTO;

namespace UMarket.Application.Contracts
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> GetAllAsync();

        Task<CategoriaDto?> GetAsync(int id);

        Task<int> CreateAsync(CategoriaCreateDto dto);

        Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
