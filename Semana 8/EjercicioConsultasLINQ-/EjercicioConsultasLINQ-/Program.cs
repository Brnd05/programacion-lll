//Ejecucion Diferida

//Fuente de Datos
var numeros = new List<int> { 1,2,3,4,5};

//Definir consulta 
var pares = numeros.Where(n => n % 2 == 0); //Ejecucion diferida

//Modificar la fuente de datos antes de enumerar
numeros.Add(6);

//Ejecucion en tiempo real
Console.WriteLine(string.Join (",",pares));

//Ejecucion Inmediata
var precios = new List<decimal> { 12.9m, 45m, 20.5m };

var mayorA20 = precios.Where(p => p > 20).ToList(); //Ejecucion Inmediata

//Cambiar fuente de datos
precios.Add(100m);

//Ejecucion en tiempo real
Console.WriteLine(string.Join(",", mayorA20));