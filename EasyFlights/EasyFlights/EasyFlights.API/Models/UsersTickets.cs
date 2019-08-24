using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Models
{
    public class UsersTickets
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid TicketID { get; set; }
        public Guid DestinationID { get; set; }
        public Guid DepartureID { get; set; }


    }
}
