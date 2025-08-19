//Listas
//Crear una lista de nombres

List<string> nombres = new List<string>();

//Agregar nombres a la lista
nombres.Add("David"); // 0
nombres.Add("Lesly"); // 1
nombres.Add("Kevin"); // 2

//Insertar en posición especifica
nombres.Insert(1, "Brandon");

//Recorrer Lista
foreach (var nombre in nombres)
{
    Console.WriteLine(nombre);
}

//Buscar en la lista
Console.WriteLine($"¿Esta Lesly? {nombres.Contains("Lesly")}");
Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

//Crear una pila de números
//El ultimo en entrar es el primero en salir
Stack<int> numeros = new Stack<int>();

//Agregar elementos
numeros.Push(1);
numeros.Push(5);
numeros.Push(10);

//Ver ultimo elemento en la píla
Console.WriteLine($"Numero que se encuentra en la cima: {numeros.Peek()}");

//Quitar elementos en la pila
Console.WriteLine($"Se saco el numero: {numeros.Pop()}");

//Recorrer la pila
foreach (var numero in numeros)
{ Console.WriteLine(numero); }
Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

//Crear Cola de clientes - FIFO
Queue<string> clientes = new Queue<string>();

clientes.Enqueue("Yessenia");
clientes.Enqueue("Josue");
clientes.Enqueue("Nubia");

//Ver primer cliente en la cola
Console.WriteLine($"Primero en la cola: {clientes.Peek()}");

//Atender cliente
Console.WriteLine($"Ateniendo a: {clientes.Dequeue()}");

//Recorrer cola
foreach (var cliente in clientes)
{ Console.WriteLine(cliente); }
Console.Read();