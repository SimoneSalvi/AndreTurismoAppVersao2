using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class CityDTO
    {
        public int Id { get; set; }

        [JsonProperty("localidade")]
        public string Description { get; set; }

    }
}
