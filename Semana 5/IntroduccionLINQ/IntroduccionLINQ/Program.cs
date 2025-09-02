//Metodo normal
//int sumar (int a, int b)
//{
//    return a + b;
//}

//int restar (int a, int b) =>  a - b;

////Funcion anonima
//Func<int, int, int> sumar = (a,b) => a + b;

//Sintaxis de consulta

////Fuente de datos
//int[] numeros = { 1, 2, 3, 4, 5, 6, 7 };

////Consultar en la fuente de datos -> LINQ

//var pares  = from n in numeros
//             where n % 2 == 0
//             select n;

//Console.Write("Numeros pares\n");
//foreach (var par in pares)
//    Console.WriteLine(par);

////Sintaxis de metodo

////Funcion anonima (lambda), dentro del metodo where
//var numeroPares = numeros.Where(n => n% 2 == 0);
//Console.Write("Numeros pares\n");
//foreach (var par in numeroPares)
//    Console.WriteLine(par);

//List<string> nombres = new() { "Ana", "Pedro", "Andres", "Lucas" };

//var nombresConA = nombres.Where(n => n.StartsWith("A"));

//Console.WriteLine("Nombres que empiean con A");
//foreach (var conA in nombresConA)
//    Console.WriteLine(conA);



//Fuente de datos
using IntroduccionLINQ;
using System.Runtime.InteropServices;

var productos = new List<Producto>
{
    new Producto {Id = 1, Nombre = "Laptop", Categoria = "Tecnologia", Precio = 999.99m},
    new Producto {Id = 1, Nombre = "Silla", Categoria = "Hogar", Precio = 19.99m},
    new Producto {Id = 1, Nombre = "Mouse", Categoria = "Tecnologia", Precio = 9.99m},
    new Producto {Id = 1, Nombre = "Café", Categoria = "Alimentos", Precio = 0.99m},
    new Producto {Id = 1, Nombre = "Taza", Categoria = "Hogar", Precio = 2.99m},
};

Console.WriteLine("SINTAXIS DE CONSULTA");

//Filtrar producto mayor a 50
var productosCaros = from p in productos where p.Precio >= 50 select p;
//Filtrar productos por categoria (Hogar)
var categoriaHogar = from p in productos where p.Categoria == "Hogar" select p;

//Impresora
void Imprimir (string titulo, IEnumerable<Producto> productos)
{
    Console.WriteLine(titulo);
    foreach (var producto in productos)
        Console.WriteLine(producto);

}

Imprimir("Caros > 50",productosCaros);
Imprimir("Productos en Hogar", categoriaHogar);

Console.WriteLine("SINTAXIS POR METODOS + LAMBDAS");
//Filtrar con where (lambda)
var productosCarosMetodo = productos.Where(p => p.Precio > 50m);

Imprimir ("Caros > 50", productosCarosMetodo);

var categoriaHogarMetodo = productos.Where(p => p.Categoria == "Hogar").Select(p => p.Nombre);

Console.WriteLine("Categoria Hogar: " + string.Join(",", categoriaHogarMetodo));