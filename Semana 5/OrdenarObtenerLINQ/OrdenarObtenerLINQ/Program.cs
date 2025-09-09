Console.WriteLine("OrderBy vs OrderBY + ThenBy");

var personas = new List<(string Nombre, int Edad)>
{
    ("Pedro", 29),
    ("Ana", 100),
    ("Pablo", 75),
    ("Lucia", 19),
    ("Brenda",100)
};

//Ordena por edad ascendente
//Mantiene el ordeb en que se insertaron
Console.WriteLine("Solo OrderBy");
var soloOrderBy = personas.OrderBy(p => p.Edad);
foreach (var persona in soloOrderBy)
{
    Console.WriteLine($"{persona.Nombre} - {persona.Edad}");
}

Console.WriteLine("OrderBy + ThenBy");
//Primero se ordena con OrderBy -> Edad
//Si hay empate de edades se usa ThenBy -> Nombre (orden alfabetico)
var orderConThenBy = personas.OrderBy(p => p.Edad).ThenBy(p => p.Nombre);
foreach (var persona in orderConThenBy)
{
    Console.WriteLine($"{persona.Nombre} - {persona.Edad}");
}

Console.WriteLine("Ordenando productos");
var productos = new List<(string Nombre, decimal precio)>
{
    ("Laptop", 999.99m),
    ("Mouse", 20.50m),
    ("Teclado", 50.00m),
    ("Monitor", 180.00m),
    ("Taza",12.00m)
};

//Producto más barato
var barato = productos.OrderBy(p => p.precio).First();
Console.WriteLine($"Producto más barato: {barato.Nombre} - {barato.precio}");
//Producto más caro
var caro = productos.OrderByDescending(p => p.precio).First();
Console.WriteLine($"Producto más caro: {caro.Nombre} - {caro.precio}");
//foreach (var producto in barato)
//{
//    Console.WriteLine($"{producto.Nombre} - {producto.precio}");
//}
var numeros = new List<int> { 3, 6, 9 };

//First(): primer elemento
//Si esta vacia la lista, genera una excepcion

int primero = numeros.First(); //3
int primeroDefault = numeros.FirstOrDefault(n => n > 20);
Console.WriteLine($"First(): {primero}");
Console.WriteLine($"First(): {primeroDefault}");

var listaVacia = new List<int>();

try
{
    var n = listaVacia.First();
}
catch(InvalidOperationException ex)
{
    Console.WriteLine($"Lista vacia, no se encontraron elementos.");
}