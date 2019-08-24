using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.Models
{
    public class TicketModel
    {
        [Required]
        public Guid ID { get; set; }
        public int Available { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        public string Seat { get; set; }
        public int Price { get; set; }
        [Required]
        public string wayString { get; set; }
        [Required]
        public string returnDate { get; set; }
        public int Bought { get; set; }
    }
}
