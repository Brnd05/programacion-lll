using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Application.DTO;

namespace UMarket.Application.Contracts
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetAllAsync();

        Task<UsuarioDto?> GetByIdAsync(int id);

        Task <int> CreateAsync(UsuarioCreateDto usuario);

        Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
