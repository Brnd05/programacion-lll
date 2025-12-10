using System.ComponentModel.DataAnnotations;

namespace PizzaUNAB.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; } = default!;
        [MaxLength(20)]
        public string? Telefono { get; set; }
        public List<Pedido> Pedidos { get; set; } = new();
    }
}
