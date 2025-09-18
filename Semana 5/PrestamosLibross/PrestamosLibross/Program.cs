using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text.Json;

namespace PrestamosLibross
{
    internal class Program
    {
        #region Modelos
        class Libros
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public bool Prestado {  get; set; }
        }

        class Prestamo
        {
            public int Id { get; set; }
            public int LibroId { get; set; }
            public string Usuario { get; set; }
            public DateTime FechaPrestamo { get; set; } = DateTime.Now;
            public DateTime? FechaDevolucion { get; set; } = null;
            public bool Activo => FechaDevolucion == null;
        }
        #endregion
        //Guardar en un archivo json
        class Data {
        public List<Libros> Libros { get; set; }
            public List<Prestamo> Prestamo { get; set; }

            public int SiguienteLibroId { get; set; } = 1;
            public int SiguientePrestamoId { get; set; } = 1;
        }
        //Ruta del archivo
        static readonly string RutaArchivo = Path.Combine(
            AppContext.BaseDirectory, "data", "biblioteca.json");
        //Configuracion para formato legible
        static readonly JsonSerializerOptions serializerOptions = new() { WriteIndented = true };
        
        //Instancia de la clase Data en memoria
        static Data BD = new Data();

        static void GuardarArchivo()
        {
            //Convierte los objetos a formato JSON
            var json = JsonSerializer.Serialize(BD, serializerOptions);
            //Guardar archivo {creear-sobreescribir}
            File.WriteAllText(RutaArchivo, json);
        }

        static void CargarDatos()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo)!);
            if (File.Exists(RutaArchivo))
            {
                //Leer archivo JSON
                var json = File.ReadAllText(RutaArchivo);
                BD = JsonSerializer.Deserialize<Data>(json, serializerOptions) ?? new Data();

            }
            else
            {
                BD = new Data();
                //Guardar el archivo vacio
                GuardarArchivo();
            }
        }


        static void Main(string[] args)
        {
            CargarDatos();
            while (true)
            {
                Console.WriteLine("Prestamos de Libros");
                Console.WriteLine("1) Agregar libro");
                Console.WriteLine("2) Prestar Libro");
                Console.WriteLine("3) Devolver libro");
                Console.WriteLine("4) Mostrar");
                Console.WriteLine("5) Salir");

                Console.WriteLine("Digitar opcion");

                switch (Console.ReadLine())
                {
                    case "1": AgregarLibro(); break;
                    case "2": PrestarLibro(); break;
                    case "3": DevolverLibro(); break;
                    case "4": Mostrar (); break;
                    case "5": return;
                    default: Console.WriteLine("Opcion invalida"); break;

                }
            }
        }

        //Operaciones
        static void AgregarLibro()
        {
            Console.WriteLine("Nombre: ");
            var nombre = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Nombre es requerido.");
                return;
            }

            var libro = new Libros { Id = BD.SiguienteLibroId++, Nombre = nombre };
            BD.Libros.Add(Libro);
            GuardarArchivo();
            Console.WriteLine($"Libro {libro.Id} agregado.");

        }

        static void PrestarLibro()
        {
            var disponible = BD.Libros.Where(libro => 1l.Prestado).ToList();
            if (disponible.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles");
                return;
            }

            Console.WriteLine("libros disponibles: ");
            foreach (var l in disponible)
            {
                Console.WriteLine($"{l.Id} {l.Nombre}");
            }

            Console.WriteLine("Id libro: ");
            If(!int.TryParse(Console.ReadLine(), out int idLibro))
            {
                Console.WriteLine("Dato invalido");
                return;
            }

            var libro = disponibles.FirstOrDefault(l => l.Id == idLibro);
            if (libro == null)
            {
                Console.WriteLine("No encontrado");
                return;
            }

            Console.WriteLine("Nombre de usuario");
            var usuario = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(usuario))
            {
                Console.WriteLine("Nombre es requerido");
                return;
            }

            var p = new Prestamo
            {
                Id = BD.SiguientePrestamoId++,
                LibroId = libro.Id,
                Usuario = usuario
            }

            libro.Prestado = true;
            BD.Prestamo.Add(p);

            GuardarArchivo
                Console.WriteLine($"Se ha prestado el libro: {libro.Nombre}");
        }

        static void DevolverLibro()
        {
            var activos = BD.Prestamo.Where(p => p.Activo).ToList();
            if (activos.Count == 0)
            {
                Console.WriteLine("No hay prestamos activos");
                return;
            }

            Console.WriteLine("Prestamos activos")
            foreach (var p in activos)
            {
                var libro = BD.Libros.First(l => l.Id == p.LibroId);
            }
        }
    }
}
