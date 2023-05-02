using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.TicketService2.Data
{
    public class AndreTurismoAppTicketService2Context : DbContext
    {
        public AndreTurismoAppTicketService2Context (DbContextOptions<AndreTurismoAppTicketService2Context> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Ticket> Ticket { get; set; } = default!;
    }
}
