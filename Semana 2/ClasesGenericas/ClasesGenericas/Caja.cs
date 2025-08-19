namespace ClasesGenericas
{
    //Clase Caja <T>
    public class Caja<T>
    {
        public T Valor { get; set; }

        public void MostrarContenido()
        {
            Console.WriteLine($"Contenido: {Valor}");
        }
    }
}
