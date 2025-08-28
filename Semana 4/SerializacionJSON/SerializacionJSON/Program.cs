//Convertir un objeto simple
using SerializacionJSON;
using System.Text.Json;

var estudiante = new Estudiante { Id = 1, Nombre = "Luis" };
var opciones = new JsonSerializerOptions
{
    WriteIndented = true //JSON legible
};
string json = JsonSerializer.Serialize(estudiante, opciones);

Console.WriteLine(json);

//Serializar objetos
var estudiantes = new List<Estudiante>
{
    new Estudiante {Id = 1, Nombre = "Ana"},
    new Estudiante {Id= 2, Nombre = "Pedro" }
};


string jsonLista = JsonSerializer.Serialize(estudiantes,
    new JsonSerializerOptions {WriteIndented = true });

Console.WriteLine(jsonLista);

//Guardar JSON
File.WriteAllText("estudiantes.json", jsonLista);
Console.WriteLine("archivo generado...");

//Ignorar propiedades
var usuario = new Usuario { Nombre = "Luis", Clave = "12345" };

var jsonUsuario = JsonSerializer.Serialize(usuario);
Console.WriteLine(jsonUsuario);

//Personalizar propiedades 
var producto = new Producto { Id = 100, Nombre = "Manzana", Precio = 1 };
var jsonProducto = JsonSerializer.Serialize(producto, opciones);
Console.WriteLine(jsonProducto);

//Serializar objeto anidado}

var pedido = new Pedido
{
    Id = 12,
    Cliente = new Cliente { Nombre = "Juan" },
    Productos = new List<Producto> { new Producto {Id = 1, Nombre = "Mouse", Precio = 12 },
    new Producto {Id = 2,Nombre="Teclado",Precio = 12}
    }

};

string jsonPedido = JsonSerializer.Serialize(pedido, opciones);
Console.WriteLine("Objetos anidados");
Console.WriteLine(jsonPedido);