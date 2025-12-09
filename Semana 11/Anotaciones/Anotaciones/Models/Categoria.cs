using System.ComponentModel.DataAnnotations;

namespace Anotaciones.Models
{
    public class Categoria
    {
        [Key] // Por convención se detecta como llave primaria, pero la podemos explicitar
        public int Id { get; set; }

        [Required, MaxLength(100)] // Requerido y limite de longitud
        public string Nombre { get; set; } = null!;
        
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
