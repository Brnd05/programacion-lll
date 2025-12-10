using PizzaUNAB.Application.DTOs;

namespace PizzaUNAB.Application.Contracts
{
    public interface IPizzaService
    {
        Task<List<PizzaDto>> GetAllAsync();
        Task<PizzaDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(PizzaCreateDto dto);
        Task<bool> UpdateAsync(int id, PizzaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
