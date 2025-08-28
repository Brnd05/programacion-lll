namespace ColeccionesGenericas
{
    public class Biblioteca
    {
        //Lista de libros
        private List<Libro> _libros = new List<Libro>();

        //Pila para historial de navegación
        private Stack<Libro> _historial = new Stack<Libro>();

        //Cola de usuarios esperando un libro
        private Queue<string> _colaUsuarios = new Queue<string
        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
            Console.WriteLine($"Libro agregado: {libro}");
        }

        public void MostrarLibros()
        {
            Console.WriteLine("Libros en la biblioteca");
            foreach (var libro in _libros)
            {
                Console.WriteLine(libro);
            }
        }

        public void SeleccionarLibro(int id)
        {
            var libro = _libros.Find(l => l.Id == id);
            if (libro != null)
            {
                _historial.Push(libro);
                Console.WriteLine($"Libro abierto: {libro.Titulo}");

            }
            else { Console.WriteLine("!!!Libro no encontrado!!!"); }
        }

        public void VolverAtras()
        {
            if (_historial.Count > 0)
            {
                var anterior = _historial.Pop();
                Console.WriteLine($"Volviste al libro: {anterior.Titulo}");
            }
            else
            {
                Console.WriteLine("No hay historial");

            }
        }

        public void AgregarUsuaioACola(string usuario)
        {
            _colaUsuarios.Enqueue(usuario);
            Console.WriteLine($"Usuario: {usuario} se unio a la cola");
            
        }

        public void AtenderUsuario ()
        {
            if (_colaUsuarios.Count > 0)
            {
                var usuario = _colaUsuarios.Dequeue();
                Console.WriteLine($"Atendiendo a: {usuario}");
            }
            else
            {
                Console.WriteLine("No hay usuarios");
            }

        }


    }
}
