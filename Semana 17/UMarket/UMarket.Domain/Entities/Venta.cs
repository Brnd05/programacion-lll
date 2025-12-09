using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Domain.Entities
{
    public class Venta
    {
        public required int Id { get; set; }
        public required DateTime Fecha { get; set; }
        public required decimal Total { get; set; }

        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        // ← Esto te faltaba
        public List<VentaDetalle> Detalles { get; set; } = new();
    }
}
