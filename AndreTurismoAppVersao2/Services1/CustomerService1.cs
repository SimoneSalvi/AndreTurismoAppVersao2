using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.AddressService;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.CustomerServices
{
    public class CustomerService1
    {
        static readonly HttpClient customerClient = new HttpClient();

        // Listar todos os Clientes
        public async Task<List<Customer>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await CustomerService1.customerClient.GetAsync("https://localhost:7290/api/Customers");
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Customer>>(customer);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Buscar Cliente por ID
        public async Task<Customer> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await CustomerService1.customerClient.GetAsync("https://localhost:7290/api/Customers" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customer);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //Inserir Cliente
        public async Task<Customer> Insert(Customer c)
        {
            try
            {
                HttpResponseMessage response = await CustomerService1.customerClient.PostAsJsonAsync("https://localhost:7290/api/Customers", c);
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customer);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Atualiza
        public async Task<Customer> Update(Customer c)
        {
            try
            {
                HttpResponseMessage response = await CustomerService1.customerClient.PutAsJsonAsync("https://localhost:7290/api/Customers" + $"/{c.Id}", c);
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customer);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Deleta
        public async Task<Customer> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await CustomerService1.customerClient.DeleteAsync("https://localhost:7290/api/Customers" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customer);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
