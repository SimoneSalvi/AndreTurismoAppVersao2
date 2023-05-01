using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fone { get; set; }
        public Address Address { get; set; }
        public DateTime DtCadstre { get; set; }
    }
}
