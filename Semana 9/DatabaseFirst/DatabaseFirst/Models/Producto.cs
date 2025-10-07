using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public string? Codigo { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;
}
