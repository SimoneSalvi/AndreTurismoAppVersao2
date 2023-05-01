using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.CityService2.Data
{
    public class AndreTurismoAppCityService2Context : DbContext
    {
        public AndreTurismoAppCityService2Context (DbContextOptions<AndreTurismoAppCityService2Context> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.City> City { get; set; } = default!;
    }
}
