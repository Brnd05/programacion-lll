using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Domain.Entities;

namespace UMarket.Application.DTO
{
    
        public class VentaDto
        {
            public required int Id { get; set; }
            public required DateTime Fecha { get; set; }
            public required decimal Total { get; set; }
            public required int UsuarioId { get; set; }
            public required UsuarioDto Usuario { get; set; }

            public List<VentaDetalleDto> Detalles { get; set; } 

    }
        public class VentaCreateDto
        {
            public required DateTime Fecha { get; set; }
            public required decimal Total { get; set; }
            public required int UsuarioId { get; set; }
            public required List<VentaDetalleDto> Detalles { get; set; }
        }

        public class VentaUpdateDto
        {
            public required DateTime Fecha { get; set; }
            public required decimal Total { get; set; }
            public required int UsuarioId { get; set; }
            public required List<VentaDetalleDto> Detalles { get; set; }
    }
    
}
