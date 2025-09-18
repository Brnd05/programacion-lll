var numeros = new List<int> {5,12,7,20,3 };

//Mostrar el minimo
var min = numeros.Min();

//Muestra el maximo
var max = numeros.Max();



//Muestra los numeros totales
var suma = numeros.Sum();

Console.WriteLine(min);
Console.WriteLine(max);


var notas = new List<double> { 7.5, 8.0, 6.0, 9.0 };
Console.WriteLine($"Promedio: " + notas.Average());

var nombres = new List<string> { "Pedro", "Ana", "Karla", "Juan" };

var totalElementos = nombres.Count();
Console.WriteLine("Numero total de elementos en la lista nombres: "+totalElementos);

var nombresConA = nombres.Count(n => n.Contains("a"));
Console.WriteLine($"nombres con A:" + nombresConA);

var precios = new List<decimal> { 100.50m, 50m, 25.25m };
var total = precios.Sum();
Console.WriteLine("suma total:"+total);

var productos = new List<(string Nombre, decimal Precio)>
{
    ("Laptop", 999.99m),
    ("Mouse", 20.50m),
    ("Teclado", 45.00m),
    ("Monitor", 180.00m),
    ("Silla", 40.99m)

};
//Mostrar precio más bajo y alto
var barato = productos.Min(p => p.Precio);
var caro = productos.Max(p => p.Precio);

//Mostrar promedio de precios
var promedio = productos.Average (p => p.Precio);

//Mostrar el total de productos
var cantidad = productos.Count();

//Mostrar la suma de precios
var totalPrecios = productos.Sum(p =>  p.Precio);
Console.WriteLine("Detalle de productos");
Console.WriteLine($"Mas barato: {barato} y el más caro es: {caro}");
Console.WriteLine($"Promedio: {promedio}, total: {totalPrecios}, cantidad: {cantidad}");