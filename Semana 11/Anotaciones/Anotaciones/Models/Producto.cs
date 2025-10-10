using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotaciones.Models
{
    public class Producto
    {
        [Key]
       public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Nombre { get; set; } = null!;

        [Column(TypeName ="decimal(10,2) ")]
        public decimal Precio { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [MaxLength(40)]
        public string? Codigo { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; } = null!;
    }
}
