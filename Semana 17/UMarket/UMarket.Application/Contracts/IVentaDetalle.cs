using System.Collections.Generic;
using System.Threading.Tasks;
using UMarket.Application.DTO;

namespace UMarket.Application.Interfaces
{
    public interface IVentaDetalleService
    {
        // Obtener todos los detalles de venta
        Task<List<VentaDetalleDto>> GetAllAsync();

        // Obtener un detalle específico por Id
        Task<VentaDetalleDto?> GetByIdAsync(int id);

        // Obtener todos los detalles de una venta específica
        Task<List<VentaDetalleDto>> GetByVentaIdAsync(int ventaId);

        // Crear un nuevo detalle de venta
        Task<int> CreateAsync(VentaDetalleCreateDto dto);

        // Actualizar un detalle existente
        Task<bool> UpdateAsync(int id, VentaDetalleUpdateDto dto);

        // Eliminar un detalle de venta
        Task<bool> DeleteAsync(int id);
    }
}