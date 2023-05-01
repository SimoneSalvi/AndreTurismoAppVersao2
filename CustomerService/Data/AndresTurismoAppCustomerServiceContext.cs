using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndresTurismoApp.CustomerService.Data
{
    public class AndresTurismoAppCustomerServiceContext : DbContext
    {
        public AndresTurismoAppCustomerServiceContext (DbContextOptions<AndresTurismoAppCustomerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Customer> Customer { get; set; } = default!;
    }
}
