namespace ColeccionesGenericas
{
    public class Restaurante
    {
        //Como medida de protección se definen las colecciones como private
        private List<Menu> _platillos = new List<Menu>();// se define el objeto menu y sus propiedades como un tipo List

        private Queue<Menu> _pedidos = new Queue<Menu>();// cola que almacena pedidos

        private Queue<string> _clientes = new Queue<string>();// cola que almacena clientes

        private Stack<string> _historial = new Stack<string>(); // pila que contendra y mostrara el historial

        //Permite agegar platillos a la lista de tipo menu y mostrar los agregados
        public void AgregarPlatillosDisponibles(Menu platillos)
        {

            _platillos.Add(platillos);
            Console.WriteLine($"Se agrego: {platillos.Nombre} ");

        }

        public void listarPlatillos()
        {
            //Se usa un foreach para recorrer la lista Menu en busca de _platillos
            Console.WriteLine("Platillos disponibles: ");
            foreach (var platillos in _platillos)
            {
                Console.WriteLine(
                    $" Categoria: {platillos.Categoria}-" +
                    $" Nombre: {platillos.Nombre}-" +
                    $" Precio: {platillos.Precio}- ");

            }

        }
        // por medio de la propiedad remove se eliminan platillos de la lista Menu

        public void EliminarPlatillos()
        {
            if (_platillos.Count > 0)
            {
                var platilloEliminado = _platillos[0];
                _platillos.RemoveAt(0);
                Console.WriteLine($"Se elimino: {platilloEliminado.Nombre}");

            }
            else
            {
                Console.WriteLine("No hay platillos para eliminar.");
            }
        }

        //con este metodo se agregan pedidos(platillos) a la cola 
        public void PedidosEnEspera(Menu pedidos)
        {
            _pedidos.Enqueue(pedidos);
        }

        //Este metodo permite recorrer la lista en busca del proximo cliente en la cola cliente
        public void ProximoCliente()
        {
            Console.WriteLine($"Proximo cliente en ser atendido: {_clientes.Peek()}");
        }

        // encola los valores string y los guarda en _clientes
        public void ClientesEnEspera(string cliente)
        {

            _clientes.Enqueue(cliente);
            Console.WriteLine($"El cliente: {cliente} se agrego a la cola de espera");
        }

        //Cada vez que se atiende un cliente se vende un platillo
        // Cada vez que este metodo se utiliza guarda un cambio por medio de un push en el historial

        public void AtendiendoPedidos()
        {

            Console.WriteLine($"Se atendio a {_clientes.Peek()}");
            _historial.Push($"Se atendio a {_clientes.Peek()}");
            _historial.Push($"Ultimo pedido: {_platillos.First().Nombre} vendido a {_clientes.Peek()}");
            _clientes.Dequeue();
            _platillos.Remove(_platillos[0]);

        }

        //Este metodo muestra el contenido actual de la cola de clientes luego de ser atendidos
        public void ClientesEsperando()
        {
            Console.WriteLine("Clientes actuales: ");
            foreach (var cliente in _clientes)
            {
                Console.WriteLine($"{cliente}");
            }

        }

        // muestra las operaciones anteriores con un foreach que recorre la pila
        public void MostrarHistorial()
        {
            foreach (var historial in _historial)
            {
                Console.WriteLine($"Historial: {historial}");
            }


        }








    }
}
