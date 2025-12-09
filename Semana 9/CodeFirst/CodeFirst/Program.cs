using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDb();


//Listar productos
var productos = db.Productos.Include(p => p.Categoria).ToList();

foreach (var product in productos)
    Console.WriteLine($"{product.Nombre} - {product.Precio} - {product.Categoria.Nombre}");


