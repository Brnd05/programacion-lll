namespace PizzaUNAB.Domain.Entities
{
    public enum EstadoPedido { Borrador = 0, Confirmado = 1, Entregado = 2, Cancelado = 3 } 

    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public DateTime FechaUtc { get; set; }
        public EstadoPedido Estado { get; set; }

        public decimal Total { get; set; }
        public List<PedidoItem> Items { get; set; } = new();
    }
}
