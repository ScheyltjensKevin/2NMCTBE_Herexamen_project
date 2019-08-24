using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFlights.Models
{
    public class Tickets
    {
        public Guid ID { get; set; }
        public int Available { get; set; }
        public string Country { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public string Seat { get; set; }
        public int Price { get; set; }
    }
}
