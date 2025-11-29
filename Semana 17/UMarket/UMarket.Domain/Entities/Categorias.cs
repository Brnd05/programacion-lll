using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Domain.Entities
{
    public class Categorias
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
