using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Domain.Entities;

namespace UMarket.Application.DTO
{
    
        public class CategoriaDto
        {
            public required int Id { get; set; }
            public required string Nombre { get; set; }
            public List<Producto> Productos { get; set; }
        }

        public class CategoriaCreateDto
        {
           
            public required string Nombre { get; set; }
            public List<Producto> Productos { get; set; }
        }

        public class CategoriaUpdateDto
        {
   
            public required string Nombre { get; set; }
            public List<Producto> Productos { get; set; }
        }

    
}
