using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CodeFirst.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength (100)]
        public string Nombre { get; set; }

        [Required,ForeignKey(nameof(Id))]
        public Especialidad EspecialidadDoctor { get; set; } = null!;


    }
}
