using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using AndreTurismoAppVersao2.Services1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.AddressService
{
    public class AddressService1
    {
        static readonly HttpClient addressClient = new HttpClient();

        // Listar todos os endereços
        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await AddressService1.addressClient.GetAsync("https://localhost:7164/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Buscar cidade por ID
        public async Task<Address> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await AddressService1.addressClient.GetAsync("https://localhost:7164/api/Addresses" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //Inserir Endereço
        public async Task<Address> Insert(Address a)
        {
            //Address address1 = new Address();
            AddressDTO addressDTO = new AddressDTO();
            try
            {
                /*
                HttpResponseMessage response = await AddressService1.addressClient.GetAsync("https://localhost:7164/api/Addresses" + $"/{cep}");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                addressDTO = JsonConvert.DeserializeObject<AddressDTO>(address);
                */

                HttpResponseMessage response = await AddressService1.addressClient.PostAsJsonAsync("https://localhost:7164/api/Addresses", a);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }


        }

        // Atualiza
        public async Task<Address> Update(Address c)
        {
            try
            {
                HttpResponseMessage response = await AddressService1.addressClient.PutAsJsonAsync("https://localhost:7164/api/Addresses" + $"/{c.Id}", c);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Deleta
        public async Task<Address> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await AddressService1.addressClient.DeleteAsync("https://localhost:7164/api/Addresses" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
