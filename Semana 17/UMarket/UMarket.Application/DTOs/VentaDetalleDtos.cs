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
        public int Id { get; set; }
        public int VentaId { get; set; }
        public VentaDto Venta { get; set; }
        public int ProductoId { get; set; }
        public ProductoDto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal => Cantidad * PrecioUnitario;
    }

    
    public class VentaDetalleCreateDto
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    
    public class VentaDetalleUpdateDto
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

}
