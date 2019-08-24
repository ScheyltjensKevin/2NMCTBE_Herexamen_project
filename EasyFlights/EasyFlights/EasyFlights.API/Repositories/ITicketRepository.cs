using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.Models;


namespace EasyFlights.API.Repositories
{
    public interface ITicketRepository
    {
        //Get
        Task<List<Tickets>> GetTickets();   // tested, but needs html/css to be shown still
        Task<Tickets> GetTicketByID(Guid TicketID); // tested, but needs html/css to be shown still
        Task<List<Tickets>> GetTicketsByCtry_Time(string origin, string destination, DateTime departureTime); // get all tickets with a certain origin, destination and departure time
        Task<List<Tickets>> GetMyTickets(Guid userID);

        Task<List<TicketAdmin>> GetAllUserTickets();
        //Put



    }
}