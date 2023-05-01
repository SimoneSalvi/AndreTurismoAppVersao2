using System.Net.Http.Json;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.Services1
{
    public class CityService1
    {
        static readonly HttpClient cityClient = new HttpClient();

        // Listar Cidades
        public async Task<List<City>> Get()
        {
            try
            {
                HttpResponseMessage response = await CityService1.cityClient.GetAsync("https://localhost:7235/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Buscar cidade por ID
        public async Task<City> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService1.cityClient.GetAsync("https://localhost:7235/api/Cities" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //Inserir Cidade
        public async Task<City> Insert(City c)
        {
            try
            {
                HttpResponseMessage response = await CityService1.cityClient.PostAsJsonAsync("https://localhost:7235/api/Cities", c);
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Atualiza
        public async Task<City> Update(City c)
        {
            try
            {
                HttpResponseMessage response = await CityService1.cityClient.PutAsJsonAsync("https://localhost:7235/api/Cities" + $"/{c.Id}", c);
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Deleta
        public async Task<City> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService1.cityClient.DeleteAsync("https://localhost:7235/api/Cities" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
