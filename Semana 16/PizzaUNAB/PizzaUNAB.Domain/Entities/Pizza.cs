using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Domain.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public List<PedidoItem> Items { get; set; }
    }
}
