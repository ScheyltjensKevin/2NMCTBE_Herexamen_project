using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.Models
{
    public class TicketModel
    {
        public Guid ID { get; set; }
        public int Available { get; set; }
        public string Country { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public string Seat { get; set; }
        public int Price { get; set; }
        public string wayString { get; set; }
        public string returnDate { get; set; }
        public int Administrator { get; set; }
    }
}
