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
    public class PackageController : ControllerBase
    {
        private readonly PackageService1 _packageService1;
        private readonly PostOfficesService _postOfficesService;

        public PackageController(PackageService1 packageService1, PostOfficesService postOfficesService)
        {
            _packageService1 = packageService1;
            _postOfficesService = postOfficesService;
        }

        // Listar todos
        [HttpGet]
        public async Task<List<Package>> GetPackage()
        {
            return await _packageService1.GetPackage();
        }

    }
}
