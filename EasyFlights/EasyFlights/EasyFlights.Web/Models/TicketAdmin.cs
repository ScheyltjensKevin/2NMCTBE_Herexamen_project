using EasyFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.Models
{
    public class TicketAdmin : Tickets
    {
        public int Administrator { get; set; } = 0; // default 0 = not an admin
    }
}
