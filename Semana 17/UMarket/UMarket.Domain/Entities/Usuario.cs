
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
        public  int Id { get; set; }
        public string Nombre { get; set; }
        public  string Correo { get; set; }
        public  string Contraseña { get; set; }

        public  Roles Rol { get; set; }
    }
}