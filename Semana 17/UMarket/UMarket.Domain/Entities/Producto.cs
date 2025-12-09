using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Domain.Entities
{
    public class Producto
    {
        public required int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

        public required decimal Precio { get; set; }

        public required int Stock { get; set; }

        public required int CategoriaId { get; set; }

        public required Categoria Categoria { get; set; }
    }
}
