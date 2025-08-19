using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGenericas
{
    public class Historial<T>
    {
        private T[] elementos;
        private int contador;


        public Historial(int capacidad)
        {
            elementos = new T[capacidad];
            contador = 0;
        }

        public void Agregar(T item)
        {
            if (contador < elementos.Length)
            {
                elementos[contador] = item ;
                contador++;

            
            }
            else {
                Console.WriteLine("No se puede agregar más elementos");
            }
        }
        public void MostrarHistorial() {
        Console.WriteLine("Historial de elementos:");
        for (int i = 0; i < contador; i++)
                Console.WriteLine($"- {elementos[i]}");
        }
    }

}
