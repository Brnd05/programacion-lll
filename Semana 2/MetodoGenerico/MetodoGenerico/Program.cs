//Echo
//Hola
using MetodoGenerico;
var echo1 = UtileriaGenerica.Echo(35);
var echo2 = UtileriaGenerica.Echo("Programacion III");

Console.WriteLine($"Echo int: {echo1}");
Console.WriteLine($"Echo string: {echo2}");

//EsIgual
Console.WriteLine($"5 es igual que 5: {UtileriaGenerica.EsIgual(5,5)}");
Console.WriteLine($"a es igual que b: {UtileriaGenerica.EsIgual("a", "b")}");

//Max
Console.WriteLine($"Maximo entre 7 y 5: {UtileriaGenerica.Max(5,7)}");

//Repetir un valor varias veces 
var repetirEnteros = UtileriaGenerica.Repetir(10,6);
Console.WriteLine($"Repeticio de Enteros: {string.Join(",", repetirEnteros)}");
Console.WriteLine("=========================================================");

void MostrarInformación<T>(T valor) { 
    Console.WriteLine($"Valor recibido: {valor}");
}

MostrarInformación<int>(50);
MostrarInformación<string>("Hola mundo");
//Operador ternario
// condición  ? valorSiEsVeradero : valorSiEsFalso

int x = 3;
string resultado = x > 0 ? "Positivo" : "Negativo";

if (x > 0)
    resultado = "Positivo";
else
    resultado = "Negativo";
    Console.ReadLine();