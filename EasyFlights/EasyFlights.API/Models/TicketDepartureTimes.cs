using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Models
{
    public class TicketDepartureTimes
    {
        public Guid ID { get; set; }
        public Guid TicketID { get; set; }
        public Guid DepartureTimeID { get; set; }

    }
}
