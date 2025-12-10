using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMarket.Domain.Entities;

namespace UMarket.Application.DTO
{

    
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }   
        public Roles Rol { get; set; }
    }

   
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public Roles Rol { get; set; }
    }

    
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public Roles Rol { get; set; }
    }
}
