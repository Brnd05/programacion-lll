using PizzaUNAB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Application.DTOs
{
    public class PedidoItemInput
    {
        public int PizzaId { get; set; }
        public int Cantidad { get; set; }
    }
    public class  PedidoItemDetalleDto
    {
        public int PizzaId { get; set; }
        public string PizzaNombre { get; set; } = default!;

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
    public class PedidoResumenDto
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public DateTime FechaUTC { get; set; }

        public EstadoPedido Estado { get; set; }

        public decimal Total { get; set; }
    }
    public class PedidoDetalleDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime FechaUTC { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Total { get; set; }
        public List<PedidoItemDetalleDto> Items { get; set; }
    }
}
