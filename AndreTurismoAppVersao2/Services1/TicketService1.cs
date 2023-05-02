using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.AddressService;
using Newtonsoft.Json;

namespace AndreTurismoAppVersao2.Services1
{
    public class TicketService1
    {
        static readonly HttpClient ticketClient = new HttpClient();

        // Listar todos os tickets
        public async Task<List<Ticket>> GetTicket()
        {
            try
            {
                HttpResponseMessage response = await TicketService1.ticketClient.GetAsync("https://localhost:7257/api/Tickets");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Ticket>>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Buscar cidade por ID
        public async Task<Ticket> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService1.ticketClient.GetAsync("https://localhost:7257/api/Tickets" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        //Inserir Ticket
        public async Task<Ticket> Insert(Ticket t)
        {
            try
            {

                HttpResponseMessage response = await TicketService1.ticketClient.PostAsJsonAsync("https://localhost:7257/api/Tickets", t);
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }


        }

        // Atualiza
        public async Task<Ticket> Update(Ticket t)
        {
            try
            {
                HttpResponseMessage response = await TicketService1.ticketClient.PutAsJsonAsync("https://localhost:7257/api/Tickets" + $"/{t.Id}", t);
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }

        // Deleta
        public async Task<Ticket> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await TicketService1.ticketClient.DeleteAsync("https://localhost:7257/api/Tickets" + $"/{id}");
                response.EnsureSuccessStatusCode();
                string ticket = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Ticket>(ticket);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
