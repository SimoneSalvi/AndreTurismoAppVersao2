using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public Customer Customer { get; set; }
        public DateTime DtTicket { get; set; }
        public decimal Value { get; set; }
    }
}
