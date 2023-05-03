namespace AndreTurismoApp.Models
{
    public class Address
    {

        public Address() { }

        public Address(AddressDTO addressDTO)
        {
            //this.Country = addressDTO.Country;
            this.ZipCode = addressDTO.ZipCode;
            this.Neighborhood = addressDTO.Neighborhood;
            this.State = addressDTO.State;
            this.Street = addressDTO.Street;
            //this.Number = addressDTO.Number;
            //this.Complement = addressDTO.Complement;
            this.City = new City() { Description = addressDTO.City };
            this.DtCadastre = DateTime.Now;
        }

        public int Id { get; set; }
        public string? Country { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; } //Bairro
        public City City { get; set; }
        public string State { get; set; }
        public string Street { get; set; } //Logradouro  
        public int Number { get; set; } //Numero
        public string Complement { get; set; }
        public DateTime DtCadastre { get; set; } //Data_Cadastro
    }
}
