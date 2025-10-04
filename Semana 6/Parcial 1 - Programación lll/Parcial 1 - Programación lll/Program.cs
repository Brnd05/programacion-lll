using System.Runtime.InteropServices;

var productos = new List<(int Id, string Nombre, decimal Precio, string Categoria)>
{

    (1, "Laptop", 999.99m, "Tecnología"),

    (2, "Mouse", 20.50m, "Tecnología"),

    (3, "Silla", 120.00m, "Hogar"),

    (4, "Café", 6.75m, "Alimentos"),

    (5, "Teclado", 45.00m, "Tecnología"),

    (6, "Taza", 12.90m, "Hogar"),

    (7, "Monitor", 180.00m, "Tecnología"),

    (8, "Mesa", 230.00m, "Hogar"),


};

//debido a que var productos es una variable y no un tipo, IEnumerable no lo reconoce directamente
void Imprimir (string Nombre, IEnumerable<(int Id, string Nombre, decimal Precio, string Categoria)> productos)
{
    Console.WriteLine(Nombre);
    foreach (var producto in productos)
    {
        Console.WriteLine($"Id: {producto.Id} - Nombre: {producto.Nombre} - Precio: {producto.Precio} Categoria: - {producto.Categoria}");

    }
}

//Filtrado con Where
//Obtener todos los productos cuya categoría sea Tecnología y cuyo precio sea mayor a 50.
var productosTec50 = from p in productos where p.Precio >= 50 && p.Categoria == "Tecnología" select p ;
Imprimir("Productos con precio de >= 50 de tecnologia", productosTec50);

//Ordenar todos los productos primero por Categoria(ascendente) y luego por precio (descendente)
var CatAscendente = productos.OrderBy(p => p.Categoria).ThenBy(p => p.Nombre);
var PrecioDescendente = productos.OrderByDescending(p => p.Precio).ThenBy(p => p.Nombre);
Imprimir("Orden ascendente por categoria", CatAscendente);
Imprimir("Orden descendente por precio", PrecioDescendente);

//Uso de select (proyeccion)
//Con esta variable y el foreach se busca e imprime unicamente los nombres de los productos de la categoria Hogar
var SoloNomnbre = from p in productos where p.Categoria == "Hogar" select  p.Nombre;
foreach (var nom in SoloNomnbre)
{
    Console.WriteLine (nom);
}
// Uso de First y FirstOrDefault
var PrimeroPorPrecio = productos.OrderBy(p => p.Precio).First();
Console.WriteLine($"Primer producto: {PrimeroPorPrecio}");


var MayorDefault = productos.FirstOrDefault((p => p.Precio > 2000));
Console.WriteLine($"Mayor precio usando FirstOrDefault: {MayorDefault}");

var MayorFirst = productos.First(p => p.Precio > 2000);
Console.WriteLine($"Mayor precio usando First: {MayorFirst}");