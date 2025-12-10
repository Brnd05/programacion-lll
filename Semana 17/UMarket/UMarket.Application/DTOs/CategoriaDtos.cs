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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<ProductoDto> Productos { get; set; } = new();
    }

    
    public class CategoriaCreateDto
    {
        public string Nombre { get; set; }
    }

    /
    public class CategoriaUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }


}
