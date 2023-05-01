using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.AddressService;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.Services1
{
    public class HotelService1
    {
        static readonly HttpClient hotelClient = new HttpClient();

        // Listar todos os hoteis
        public async Task<List<Hotel>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await HotelService1.hotelClient.GetAsync("https://localhost:7258/api/Hotels");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }


        // Buscar hotel por ID
        public async Task<Hotel> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService1.hotelClient.GetAsync("https://localhost:7258/api/Hotels" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //Inserir hotel
        public async Task<Hotel> Insert(Hotel h)
        {
            try
            {
                HttpResponseMessage response = await HotelService1.hotelClient.PostAsJsonAsync("https://localhost:7258/api/Hotels", h);
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }


        }

        // Atualiza
        public async Task<Hotel> Update(Hotel h)
        {
            try
            {
                HttpResponseMessage response = await HotelService1.hotelClient.PutAsJsonAsync("https://localhost:7258/api/Hotels" + $"/{h.Id}", h);
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Deleta
        public async Task<Hotel> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await HotelService1.hotelClient.DeleteAsync("https://localhost:7258/api/Hotels" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(hotel);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
