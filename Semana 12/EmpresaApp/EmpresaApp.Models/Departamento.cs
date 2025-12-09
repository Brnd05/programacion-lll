using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaApp.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;


        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

  
    }
}
