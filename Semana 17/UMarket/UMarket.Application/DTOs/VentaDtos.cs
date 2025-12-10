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
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public List<VentaDetalleDto> Detalles { get; set; } = new();
    }

    
    public class VentaCreateDto
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public List<VentaDetalleCreateDto> Detalles { get; set; } = new();
    }

    public class VentaUpdateDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public List<VentaDetalleUpdateDto> Detalles { get; set; } = new();
    }

}
