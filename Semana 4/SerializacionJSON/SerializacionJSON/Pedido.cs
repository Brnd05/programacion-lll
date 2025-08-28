using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionJSON
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }

        public List<Producto> Productos { get; set; }
   
    }
}
