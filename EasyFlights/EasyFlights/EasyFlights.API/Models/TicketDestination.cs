using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Models
{
    public class TicketDestination
    {

        public Guid ID { get; set; }
        public Guid TicketID { get; set; }
        public Guid CountryID { get; set; }

    }
}
