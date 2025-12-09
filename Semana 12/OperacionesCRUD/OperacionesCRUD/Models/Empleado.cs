using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesCRUD.Models
{
    public  class Empleado
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Nombre  { get; set; } = string.Empty;

        public decimal Salario { get; set; }


        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; } = null!;

    }
}
