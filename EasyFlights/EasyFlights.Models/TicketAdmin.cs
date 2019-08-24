using EasyFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Models
{
    public class TicketAdmin : Tickets
    {
        public string Role { get; set; } 
        public string Email { get; set; }
    }
}
