using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using AndreTurismoAppVersao2.AddressService;
using AndreTurismoAppVersao2.Services1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoAppVersao2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService1 _hotelService1;
        private readonly PostOfficesService _postOfficesService;

        public HotelController(HotelService1 hotelService1, PostOfficesService postOfficesService)
        {
            _hotelService1 = hotelService1;
            _postOfficesService = postOfficesService;
        }

        // Listar todos
        [HttpGet]
        public async Task<List<Hotel>> GetAddress()
        {
            return await _hotelService1.GetAddress();
        }

        // Busca por Id
        [HttpGet("{id}")]
        public async Task<Hotel> GetById(int id)
        {
            return await _hotelService1.GetById(id);
        }

        // Inserir novo
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostAddress(Hotel hotel, string cep)
        {
            var addressDTO = _postOfficesService.GetAddress(cep).Result;

            //            hotel.Address.Number = n;
            hotel.Address.Neighborhood = addressDTO.Neighborhood;
            hotel.Address.Complement = addressDTO.Complement;
            hotel.Address.ZipCode = addressDTO.ZipCode;
            hotel.Address.Country = addressDTO.Country;
            hotel.Address.State = addressDTO.State;
            hotel.Address.Street = addressDTO.Street;
            hotel.Address.City = new City()
            {
                Description = addressDTO.City
            };
            //address2.City.Description = addressDTO.City;
            //address2.City.DtCadastro = DateTime.UtcNow();

            return await _hotelService1.Insert(hotel);
        }

        //Atualiza 
        [HttpPut("{id}")]
        public async Task<Hotel> Update(Hotel h)
        {
            return await _hotelService1.Update(h);
        }

        // Deleta 
        [HttpDelete("{id}")]
        public async Task<Hotel> Delete(int id)
        {
            return await _hotelService1.Delete(id);
        }

    }
}
