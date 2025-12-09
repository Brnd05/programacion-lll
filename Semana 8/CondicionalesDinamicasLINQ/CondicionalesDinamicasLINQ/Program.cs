var numeros = new List<int>
{
    6,4,2,7,3,8,9,1,
};

Console.WriteLine("Lista Original:");
Console.WriteLine(string.Join(",",numeros));


//SkipWhile
//Saltar los numeros mientras sean pares

var despuesDeImpares = numeros.SkipWhile(x  => x % 2 == 0);

Console.WriteLine("SkipWhile: saltar mientras sean pares");
Console.WriteLine(string.Join(",", despuesDeImpares));

//TakeWhile
//Tomar los numeros mientras sean pares 

var soloPares = numeros.TakeWhile(x => x % 2==0);

Console.WriteLine("TakeWhile: tomar mientras sean pares:");
Console.WriteLine(string.Join(",",soloPares));

//Any 

bool hayNumerosMayoresA10 = numeros.Any(n => n > 10);
Console.WriteLine("Existe un numero mayor a 10 " + hayNumerosMayoresA10);


//All
//Todos los numeros son positivos?
bool todosSonPositivos = numeros.All(n => n > 0);
Console.WriteLine("Todos los numeros son positivos " + todosSonPositivos);

//Temperatura }
var temperaturas = new List<int>
{
    18,19,21,23,26,29,31,33,35,34,30,27,24
};
Console.WriteLine("Temperaturs °C");
Console.WriteLine(string.Join(",", temperaturas));


var temperaturaFresca = temperaturas.TakeWhile(t => t < 30);
Console.WriteLine("Temperatura Fresca: " + string.Join(",", temperaturaFresca));

var temperaturaCaliente = temperaturas.SkipWhile(t => t < 30);
Console.WriteLine("Temperaturas Caliente: " + string.Join(",", temperaturaCaliente));


var temperaturaExtrema = temperaturas.Any (t => t > 35);
Console.WriteLine("Temperatura Extrema: " + temperaturaExtrema);
