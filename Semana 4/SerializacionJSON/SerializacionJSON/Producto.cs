using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializacionJSON
{
    public class Producto
    {
        [JsonPropertyName("codigo")]
        public int Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Nombre { get; set; }
        public int Precio { get; set; }
    }
}
