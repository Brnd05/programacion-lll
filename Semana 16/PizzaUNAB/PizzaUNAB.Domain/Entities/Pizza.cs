using System.ComponentModel.DataAnnotations;

namespace PizzaUNAB.Domain.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; } = default!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public List<PedidoItem> Items { get; set; } = new();
    }
}
