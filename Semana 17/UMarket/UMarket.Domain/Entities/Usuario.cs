
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Domain.Entities
{
    public enum Roles { Administrador =  1, Cliente = 2, Vendedor = 3 }
    public class Usuario
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        public required string Contraseña { get; set; }

        public required Roles Rol { get; set; }
    }
}