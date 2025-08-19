namespace ColeccionesGenericas
{
    public class Biblioteca
    {
        //Lista de libros
        private List<Libro> _libros = new List<Libro>();

        //Pila para historial de navegación
        private Stack<Libro> _historial = new Stack<Libro>();

        //Cola de usuarios esperando un libro
        private Queue<Libro> _colaUsuarios = new Queue<Libro>();

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
        }
    }
}
