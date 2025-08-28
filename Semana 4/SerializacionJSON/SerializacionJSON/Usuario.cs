using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SerializacionJSON
{
    public class Usuario
    {
        public string Nombre {  get; set; }

        [JsonIgnore]
        public string Clave { get; set; }
    }
}
