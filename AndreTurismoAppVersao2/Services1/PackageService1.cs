using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.AddressService;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.Services1
{
    public class PackageService1
    {
        static readonly HttpClient packageClient = new HttpClient();

        // Listar todos os endereços
        public async Task<List<Package>> GetPackage()
        {
            try
            {
                HttpResponseMessage response = await PackageService1.packageClient.GetAsync("https://localhost:7271/api/Packages");
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Package>>(package);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

    }
}
