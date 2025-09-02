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
            Console.WriteLine("Hello, World!");
        }
    }
}
