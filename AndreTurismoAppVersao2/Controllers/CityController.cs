using AndreTurismoApp.Models;
using AndreTurismoAppVersao2.Services1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoAppVersao2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly CityService1 _cityService;
        public CityController(CityService1 cityService)
        {
            _cityService = cityService;
        }

        // Lista todos
        [HttpGet]
        public async Task<List<City>> Get()
        {
            return await _cityService.Get();
        }

        // Busca por Id
        [HttpGet("{id}")]
        public async Task<City> GetById(int id)
        {
            return await _cityService.GetById(id);
        }

        // Insere novo
        [HttpPost]
        public async Task<ActionResult<City>> PostAddress(City city)
        {
            return await _cityService.Insert(city);
        }

        //Atualiza 
        [HttpPut("{id}")]
        public async Task<City> Update(City c)
        {
            return await _cityService.Update(c);
        }

        // Deleta 
        [HttpDelete("{id}")]
        public async Task<City> Delete(int id)
        {
            return await _cityService.Delete(id);
        }
    }   
}
