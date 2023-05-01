using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class HotelDTO
    {
        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("endereco")]
        public string Address { get; set; }

        [JsonProperty("dataCadastro")]
        public DateTime DtCadastre { get; set; }

        [JsonProperty("valor")]
        public decimal Value { get; set; }
    }
}
