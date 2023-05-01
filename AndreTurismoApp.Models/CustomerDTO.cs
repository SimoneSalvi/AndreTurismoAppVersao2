using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class CustomerDTO
    {
        [JsonProperty("nome")]
        public string Description { get; set; }

        [JsonProperty("fone")]
        public string Fone { get; set; }

        [JsonProperty("endereco")]
        public string Address { get; set; }
    }
}
