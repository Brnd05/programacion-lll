

using Interfaces;

IClienteRepositorio clienteRepositorio = new ClienteRepositorio();
Console.WriteLine("INTERFACES");
clienteRepositorio.Agregar("Juan");
clienteRepositorio.Agregar("Ana");
clienteRepositorio.Agregar("Pedro");

Console.WriteLine("Listado actual");

foreach (var item in clienteRepositorio.ObtenerTodos())
{
    Console.WriteLine(item);
}

clienteRepositorio.Eliminar("Juan");
Console.WriteLine("Listado despues de eliminar");
foreach (var item in clienteRepositorio.ObtenerTodos())
    Console.WriteLine(item);

Console.WriteLine("INTERFACES GENERICAS");
IRepositorio<string> repofrutas = new Repositorio<string>();
repofrutas.Agregar("Pera");
repofrutas.Agregar("Piña");
repofrutas.Agregar("Fresa");

foreach (var item in repofrutas.ObtenerTodos())
    Console.WriteLine($"Fruta: {item}");


IRepositorio<Cliente> repoCliente = new Repositorio<Cliente>();
repoCliente.Agregar(new Cliente { Id = 1, Nombre = "Juan Pérez" });
repoCliente.Agregar(new Cliente { Id = 2, Nombre = "Ana Pérez" });

foreach (var item in repoCliente.ObtenerTodos())
  Console.WriteLine($"Cliente: {item.Nombre}");

Console.Read();
class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}