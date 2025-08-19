using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGenericas
{
    public class Usuario
    {
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"Usuario: {Nombre}";
        }
    }
}
