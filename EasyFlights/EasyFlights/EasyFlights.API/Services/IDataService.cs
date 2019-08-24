using EasyFlights.API.Models;
using EasyFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Services
{
    public interface IDataService
    {
        //Tickets
        //Get
        Task<List<Tickets>> GetTickets();
        Task<Tickets> GetTicketByID(Guid TicketID);
        Task<List<Tickets>> GetMyTickets(Guid userID);
        Task<List<Tickets>> GetTicketsByDestDepT(string origin,string destination, DateTime time);
        Task<List<TicketAdmin>> GetAllUserTickets();

        //Users
        //GET
        Task<List<User>> GetUsers();
        Task<User> GetUserByID(Guid id);
        Task<User> GetUserByName(string name);
        //Post
        Task<User> AddUser(User user);
        //Put
        Task<User> UpdateUser(User user);
        Task ReserveTicket(UsersTickets uTicket);
        Task CancelTicket(UsersTickets uTicket);
        //Delete
        Task DeleteUser(Guid id);

        //Countries
        //Get
        Task<List<Countries>> GetAllCountriesAsync();
        Task<Countries> GetCountryByIdAsync(Guid id);
        Task<Countries> GetCountryByName(string country);
        Task<List<Countries>> GetAllCountriesByTicketID(Guid TicketID);

        //Departure Times
        //Get
        Task<List<DepartureTimes>> GetAllDepartureTimes();
        Task<DepartureTimes> GetDepartureTimeByID(Guid id);
        Task<DepartureTimes> GetDepartureTimesByTime(DateTime time);
        Task<List<DepartureTimes>> GetDepartureTimesByTicketID(Guid TicketID);
    }
}
