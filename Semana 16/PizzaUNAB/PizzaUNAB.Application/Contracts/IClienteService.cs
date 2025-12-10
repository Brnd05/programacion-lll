using PizzaUNAB.Application.DTOs;

namespace PizzaUNAB.Application.Contracts
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ClienteCreateDto dto);
        Task<bool> UpdateAsync(int id, ClienteUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
