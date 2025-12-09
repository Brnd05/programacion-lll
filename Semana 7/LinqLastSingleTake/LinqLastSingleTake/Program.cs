//Fuente de datos
var numeros = new List<int> { 2,4,6,8 };

//Ultimo elemento de la secuencia
int ultimo = numeros.LastOrDefault();


//Ultimo elemento que cumpla una condicion
int ultimoMayorAs = numeros.LastOrDefault(n => n > 5);

//Si no existe un valor quue coincida se muestra un valor por defecto
int ultimoMayorAs10 = numeros.LastOrDefault(n => n > 10);
Console.WriteLine(ultimo);
Console.WriteLine(ultimoMayorAs);
Console.WriteLine(ultimoMayorAs10);

Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
var nombres = new List<string> { "Ana", "Lucia", "Pedro", "Ana" };
string lucia = nombres.SingleOrDefault(n => n == "Lucia");


//Si no hay elementos que cumplan la condicion
string juan = nombres.SingleOrDefault(n => n == "Juan");

//string ana = nombres.SingleOrDefault(n => n == "Ana");
Console.WriteLine(juan);
Console.WriteLine(lucia);
//Console.WriteLine(ana);

var datos = Enumerable.Range(1,10).ToList(); //1....10
Console.WriteLine("Lista de numeros" + string.Join(",",datos));

var saltar3 = datos.Skip(3);
////4
Console.WriteLine(string.Join(",", saltar3));
var tomar5  = datos.Take(5);
Console.WriteLine(string.Join(",", tomar5));