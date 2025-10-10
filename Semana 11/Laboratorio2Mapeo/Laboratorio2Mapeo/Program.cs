using System.Linq;
using Laboratorio2Mapeo.Models;

var contexto = new Lab2Context();
var Mostrar = contexto.ComponentesPcs.ToList();


foreach (var Listar in Mostrar)
    {
        Console.WriteLine($"Modelo: {Listar.Modelo}, Procesador: {Listar.Procesador}");
    }
