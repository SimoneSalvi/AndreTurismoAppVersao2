
using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using AndreTurismoAppVersao2.AddressService;
using AndreTurismoAppVersao2.Services1;
using Microsoft.AspNetCore.Mvc;


namespace AndreTurismoAppVersao2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService1 _addressService1;
        private readonly PostOfficesService _postOfficesService;

        public AddressController(AddressService1 addressService1, PostOfficesService postOfficesService)
        {
            _addressService1 = addressService1;
            _postOfficesService = postOfficesService;
        }

        // Listar todos
        [HttpGet]
        public async Task<List<Address>> GetAddress()
        {
            return await _addressService1.GetAddress();
        }

        // Busca por Id
        [HttpGet("{id}")]
        public async Task<Address> GetById(int id)
        {
            return await _addressService1.GetById(id);
        }

        // Inserir novo
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            var addressDTO = _postOfficesService.GetAddress(address.ZipCode).Result;

            Address address2 = new(addressDTO);
            
            address2.Number = address.Number;
            address2.Complement = address.Complement;
            address2.Country = address.Country;
            await _addressService1.Insert(address2);
            
            return Ok(address2);
        }

        //Atualiza 
        [HttpPut("{id}")]
        public async Task<Address> Update(Address c)
        {
            return await _addressService1.Update(c);
        }

        // Deleta 
        [HttpDelete("{id}")]
        public async Task<Address> Delete(int id)
        {
            return await _addressService1.Delete(id);
        }
    }
}
