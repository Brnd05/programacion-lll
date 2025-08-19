using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IClienteRepositorio
    {
        void Agregar(string item);
        bool Eliminar (string item);

        List<string> ObtenerTodos();
    }
       
}
