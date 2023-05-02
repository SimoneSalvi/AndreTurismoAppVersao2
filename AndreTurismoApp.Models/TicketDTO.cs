using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class TicketDTO
    {
        [JsonProperty("Origem")]
        public string Origin { get; set; }

        [JsonProperty("Destino")]
        public string Destination { get; set; }

        [JsonProperty("Cliente")]
        public string Customer { get; set; }

        [JsonProperty("Data")]
        public DateTime DtTicket { get; set; }

        [JsonProperty("Valor")]
        public decimal Value { get; set; }
    }
}
