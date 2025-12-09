using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CodeFirst.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [Required, MaxLength (250)]
        public string Descripcion { get; set; }
    }
}
