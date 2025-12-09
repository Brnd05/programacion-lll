using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Application.DTOs
{
    public class PizzaDtos
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = default!;

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
    public class PizzaCreateDto
    {
        public string Nombre { get; set; } = default!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
    public class PizzaUpdateDto
    {
        public string Nombre { get; set; } = default!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
