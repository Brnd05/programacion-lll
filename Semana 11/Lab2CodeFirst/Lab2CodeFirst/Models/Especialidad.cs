using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CodeFirst.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string NombreEspecialidad { get; set; }
    }
}
