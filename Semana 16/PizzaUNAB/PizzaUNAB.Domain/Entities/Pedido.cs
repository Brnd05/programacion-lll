using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Domain.Entities
{
    public enum EstadoPedido {Borrador = 0, Confirmado = 1, Entregado = 2, Cancelado = 3 }
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public DateTime FechaUTC { get; set; }

        public EstadoPedido Estado { get; set; }

        public List<PedidoItem> Items { get; set; }
    }
}
