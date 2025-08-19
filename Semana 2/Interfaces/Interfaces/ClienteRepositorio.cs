using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private List<string> _list = new();  
        public void Agregar(string item)
        {
           _list.Add(item);
            Console.WriteLine($"Elemento {item} agregado. ");
        }

        public bool Eliminar(string item)
        {
            bool eliminado = _list.Remove(item);
            if (eliminado)
                Console.WriteLine("Eliminado");
            else
                Console.WriteLine("Elemento no encontrado");
            return eliminado;
        }

        public List<string> ObtenerTodos() => _list;

    }
}
