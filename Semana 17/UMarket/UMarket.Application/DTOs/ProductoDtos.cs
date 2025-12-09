using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Application.DTO
{
    
        public class ProductoDto
        {
            public required int Id { get; set; }

            public required string Nombre { get; set; }

            public required string Descripcion { get; set; }

            public required decimal Precio { get; set; }

            public required int Stock { get; set; }

            public required int CategoriaId { get; set; }

            public required CategoriaDto Categoria { get; set; }
        }

        public class ProductoCreateDto
        {
            public required string Nombre { get; set; }
            public required string Descripcion { get; set; }
            public required decimal Precio { get; set; }
            public required int Stock { get; set; }
            public required int CategoriaId { get; set; }
            
        }

        public class ProductoUpdateDto
        {
            public required string Nombre { get; set; }
            public required string Descripcion { get; set; }
            public required decimal Precio { get; set; }
            public required int Stock { get; set; }
            public required int CategoriaId { get; set; }
        }
    
}
