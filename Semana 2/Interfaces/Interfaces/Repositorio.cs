using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
     public class Repositorio<T> : IRepositorio<T>
    {
        private List<T> _list = new();

        public void Agregar (T item) => _list.Add(item);


        public IEnumerable<T> ObtenerTodos() => _list;

    }
}
