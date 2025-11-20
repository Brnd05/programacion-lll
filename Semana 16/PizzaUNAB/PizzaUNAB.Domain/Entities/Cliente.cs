using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Domain.Entities
{
    public class Cliente
    { 
        public int Id { get; set; }

        [MaxLength(150)]
        public string Nombre { get; set; } = default!;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        public list<Pedido> Pedidos { get; set; }
    }
}
