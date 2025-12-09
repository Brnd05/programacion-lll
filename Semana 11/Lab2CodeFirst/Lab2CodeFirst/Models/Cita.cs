using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CodeFirst.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(Id))]
        public Doctor Doctor { get; set; } = null!;

        [Required, ForeignKey(nameof(Id))]
        public Paciente Paciente { get; set; } = null!;
    }
}
