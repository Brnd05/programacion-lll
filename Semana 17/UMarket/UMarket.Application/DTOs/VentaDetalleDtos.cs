using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Domain.Entities;

namespace UMarket.Application.DTO
{
    
        public class VentaDetalleDto
        {
            public required int Id { get; set; }
            public required int VentaId { get; set; }
            public required Venta Venta { get; set; }
            public required int ProductoId { get; set; }
            public required ProductoDto Producto { get; set; }
            public required int Cantidad { get; set; }
            public required decimal PrecioUnitario { get; set; }
            public decimal SubTotal => Cantidad * PrecioUnitario;
        }

        public class VentaDetalleCreateDto
        {
            public required int VentaId { get; set; }
            public required int ProductoId { get; set; }
            public required int Cantidad { get; set; }
            public required decimal PrecioUnitario { get; set; }
            public  decimal SubTotal => Cantidad * PrecioUnitario;
        }

        public class VentaDetalleUpdateDto
        {
            public required int VentaId { get; set; }
            public required int ProductoId { get; set; }
            public required int Cantidad { get; set; }
            public required decimal PrecioUnitario { get; set; }
            public decimal SubTotal => Cantidad * PrecioUnitario;
        }
    
}
