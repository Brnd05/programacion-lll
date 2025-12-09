using System.ComponentModel.DataAnnotations;

namespace OperacionesCRUD.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Nombre { get; set; } = string.Empty;


        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    }
}
