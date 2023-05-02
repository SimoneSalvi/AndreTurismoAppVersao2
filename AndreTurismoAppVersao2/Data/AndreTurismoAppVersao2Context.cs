using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoAppVersao2.Data
{
    public class AndreTurismoAppVersao2Context : DbContext
    {
        public AndreTurismoAppVersao2Context (DbContextOptions<AndreTurismoAppVersao2Context> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Customer> Customer { get; set; } = default!;

        public DbSet<AndreTurismoApp.Models.Ticket>? Ticket { get; set; }
    }
}
