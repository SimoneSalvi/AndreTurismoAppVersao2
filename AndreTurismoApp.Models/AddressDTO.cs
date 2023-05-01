using Newtonsoft.Json;

namespace AndreTurismoApp.Models
{
    public class AddressDTO
    {
        public int Id { get; set; }

        [JsonProperty("pais")]
        public string? Country { get; set; }

        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; set; } //Bairro

        [JsonProperty("localidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; } //Logradouro  

        [JsonProperty("gia")]
        public int Number { get; set; } //Numero

        [JsonProperty("complemento")]
        public string Complement { get; set; }
    }
}
