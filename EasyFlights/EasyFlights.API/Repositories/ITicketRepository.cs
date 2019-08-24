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
        Task<List<Tickets>> GetTickets();   
        Task<Tickets> GetTicketByID(Guid TicketID);
        Task<List<Tickets>> GetTicketsByCtry_Time(string origin, string destination, DateTime departureTime);
        Task<List<Tickets>> GetMyTickets(Guid userID);

        Task<List<TicketAdmin>> GetAllUserTickets();
        //Put

        Task DeleteTickets(Guid userID);

    }
}