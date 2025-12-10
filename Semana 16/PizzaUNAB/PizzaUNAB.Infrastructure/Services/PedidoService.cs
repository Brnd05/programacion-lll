using Microsoft.EntityFrameworkCore;
using PizzaUNAB.Application.Contracts;
using PizzaUNAB.Application.DTOs;
using PizzaUNAB.Domain.Entities;
using PizzaUNAB.Infrastructure.Data;

namespace PizzaUNAB.Infrastructure.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly PizzeriaDb _db;
        public PedidoService(PizzeriaDb db) => _db = db;

        public async Task<int> CrearBorradorAsync(int clienteId)
        {
            var cli = await _db.Clientes.FindAsync(clienteId)
                ?? throw new InvalidOperationException("Cliente no existe.");

            var ped = new Pedido
            {
                ClienteId = clienteId,
                FechaUtc = DateTime.UtcNow,
                Estado = EstadoPedido.Borrador,
                Total = 0m
            };

            _db.Pedidos.Add(ped);
            await _db.SaveChangesAsync();
            return ped.Id;
        }

        public async Task AgregarItemAsync(int pedidoId, int pizzaId, int cantidad)
        {
            if (cantidad <= 0) throw new InvalidOperationException("Cantidad inválida.");

            var ped = await _db.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == pedidoId)
                ?? throw new InvalidOperationException("Pedido no existe.");

            if (ped.Estado != EstadoPedido.Borrador)
                throw new InvalidOperationException("Solo se edita en Borrador.");

            var pizza = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == pizzaId)
                ?? throw new InvalidOperationException("Pizza no existe.");

            var yaPedida = ped.Items.Where(i => i.PizzaId == pizzaId).Sum(i => i.Cantidad);
            if (yaPedida + cantidad > pizza.Stock)
                throw new InvalidOperationException("No hay stock suficiente.");

            var item = new PedidoItem
            {
                PedidoId = ped.Id,
                PizzaId = pizza.Id,
                Cantidad = cantidad,
                PrecioUnitario = pizza.Precio,
                Subtotal = cantidad * pizza.Precio
            };
            ped.Items.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task QuitarItemAsync(int pedidoItemId)
        {
            var item = await _db.PedidoItems.FindAsync(pedidoItemId)
                ?? throw new InvalidOperationException("Item no existe.");

            var pedido = await _db.Pedidos.FindAsync(item.PedidoId)
                ?? throw new InvalidOperationException("Pedido no existe.");

            if (pedido.Estado != EstadoPedido.Borrador)
                throw new InvalidOperationException("Solo se edita en Borrador.");

            _db.PedidoItems.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<PedidoDetalleDto?> ObtenerDetalleAsync(int pedidoId)
        {
            var p = await _db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Items).ThenInclude(i => i.Pizza)
                .FirstOrDefaultAsync(p => p.Id == pedidoId);

            if (p is null) return null;

            var dto = new PedidoDetalleDto
            {
                Id = p.Id,
                ClienteId = p.ClienteId,
                ClienteNombre = p.Cliente!.Nombre,
                FechaUtc = p.FechaUtc,
                Estado = p.Estado,
                Total = p.Total,
                Items = p.Items.Select(i => new PedidoItemDetalleDto
                {
                    PizzaId = i.PizzaId,
                    PizzaNombre = i.Pizza!.Nombre,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario,
                    Subtotal = i.Subtotal
                }).ToList()
            };

            return dto;
        }

        public async Task ConfirmarAsync(int pedidoId)
        {
            var p = await _db.Pedidos
                .Include(p => p.Items).ThenInclude(i => i.Pizza)
                .FirstOrDefaultAsync(p => p.Id == pedidoId)
                ?? throw new InvalidOperationException("Pedido no existe.");

            if (p.Estado != EstadoPedido.Borrador)
                throw new InvalidOperationException("El pedido ya fue procesado.");

            // Validar stock y recalcular subtotales
            foreach (var i in p.Items)
            {
                if (i.Cantidad <= 0) throw new InvalidOperationException("Cantidad inválida.");
                if (i.Pizza is null) throw new InvalidOperationException("Pizza inválida.");

                if (i.Cantidad > i.Pizza.Stock)
                    throw new InvalidOperationException($"Sin stock de {i.Pizza.Nombre}.");

                i.PrecioUnitario = i.Pizza.Precio;
                i.Subtotal = i.Cantidad * i.PrecioUnitario;
            }

            p.Total = p.Items.Sum(i => i.Subtotal);

            // Descontar stock
            foreach (var i in p.Items)
            {
                i.Pizza!.Stock -= i.Cantidad;
            }

            p.Estado = EstadoPedido.Confirmado;
            await _db.SaveChangesAsync();
        }

        public async Task CambiarEstadoAsync(int pedidoId, EstadoPedido nuevoEstado)
        {
            var p = await _db.Pedidos.FindAsync(pedidoId)
                ?? throw new InvalidOperationException("Pedido no existe.");

            if (p.Estado == EstadoPedido.Borrador && nuevoEstado == EstadoPedido.Entregado)
                throw new InvalidOperationException("Primero confirma el pedido.");

            p.Estado = nuevoEstado;
            await _db.SaveChangesAsync();
        }

        public async Task<List<PedidoResumenDto>> ListarAsync(EstadoPedido? estado = null)
        {
            var q = _db.Pedidos.Include(p => p.Cliente).AsQueryable();
            if (estado is not null) q = q.Where(p => p.Estado == estado);

            return await q
                .OrderByDescending(p => p.FechaUtc)
                .Select(p => new PedidoResumenDto
                {
                    Id = p.Id,
                    ClienteId = p.ClienteId,
                    ClienteNombre = p.Cliente!.Nombre,
                    FechaUtc = p.FechaUtc,
                    Estado = p.Estado,
                    Total = p.Total
                })
                .ToListAsync();
        }
    }
}
