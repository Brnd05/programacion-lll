using PizzaUNAB.Application.DTOs;
using PizzaUNAB.Domain.Entities;

namespace PizzaUNAB.Application.Contracts
{
    public interface IPedidoService
    {
        Task<int> CrearBorradorAsync(int clienteId); 
        Task AgregarItemAsync(int pedidoId, int pizzaId, int cantidad);
        Task QuitarItemAsync(int pedidoItemId);
        Task<PedidoDetalleDto?> ObtenerDetalleAsync(int pedidoId);

        Task ConfirmarAsync(int pedidoId);           
        Task CambiarEstadoAsync(int pedidoId, EstadoPedido nuevoEstado);

        Task<List<PedidoResumenDto>> ListarAsync(EstadoPedido? estado = null);
    }
}
