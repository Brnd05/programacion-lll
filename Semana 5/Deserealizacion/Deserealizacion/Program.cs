using Deserealizacion;
using System.Text.Json;

string json = "{\"Id\": 1, \"Nombre\": \"Ana\"}";
Console.WriteLine(json);

Empleado empleado = JsonSerializer.Deserialize<Empleado>(json);

Console.WriteLine($" { empleado.Id } - { empleado.Nombre }");

string jsonLista = @"[
{""Id"": 1, ""Nombre"": ""Laptop"", ""Precio"": 999.99},
{""Id"": 2, ""Nombre"": ""Mouse"", ""Precio"": 15.99}
]";

Console.WriteLine(jsonLista);

File.WriteAllText("productos.json", jsonLista);

List<Producto> productos = JsonSerializer.Deserialize<List<Producto>>(jsonLista);
foreach (var producto in productos)
{
    Console.WriteLine($"" +
    $"{producto.Id} : {producto.Nombre}" +
    $" - {producto.Precio}");
}

//Leer archivo json
string archivoJSON = File.ReadAllText("productos.json");
List<Producto> productosArchivo =
    JsonSerializer.Deserialize<List<Producto>>(archivoJSON);

Console.WriteLine($"Se cargaron { productosArchivo.Count} productos");