using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class PackageDTO
    {
        [JsonProperty("nome")]
        public string Hotel { get; set; }

        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("data")]
        public DateTime DtCadastre { get; set; }

        [JsonProperty("valor")]
        public decimal Value { get; set; }

        [JsonProperty("cliente")]
        public string Customer { get; set; }
    }
}
