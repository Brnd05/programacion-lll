using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Domain.Entities
{
     public class VentaDetalle
    {
        public required int Id { get; set; }
        public required int VentaId { get; set; }
        public required Venta Venta { get; set; }
        public required int ProductoId { get; set; }
        public required Producto Producto { get; set; }
        public required int Cantidad { get; set; }
        public required decimal PrecioUnitario { get; set; }
        public decimal SubTotal => Cantidad * PrecioUnitario;
    }
}
