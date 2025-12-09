using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMarket.Application.DTO
{
   
        public enum Roles { Administrador = 1, Cliente = 2, Vendedor = 3 }
        public class UsuarioDto
        {
            public required int Id { get; set; }
            public required string Nombre { get; set; }
            public required string Correo { get; set; }
            public required string Contraseña { get; set; }

            public required Roles Rol { get; set; }
        }

        public class UsuarioCreateDto
        {
            public required string Nombre { get; set; }
            public required string Correo { get; set; }
            public required string Contraseña { get; set; }
            public required Roles Rol { get; set; }
        }

        public class UsuarioUpdateDto
        {
            public required string Nombre { get; set; }
            public required string Correo { get; set; }
            public required string Contraseña { get; set; }
            public required Roles Rol { get; set; }
        }
    
}
