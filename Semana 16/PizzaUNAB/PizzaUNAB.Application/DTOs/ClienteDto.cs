using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaUNAB.Application.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Telefono { get; set; }
    }
    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = default!;
        public string? Telefono { get; set; }
    }
    public class  ClienteUpdateDto
    {
        public string Nombre { get; set; } = default!;
        public string? Telefono { get; set; }
    }
}
