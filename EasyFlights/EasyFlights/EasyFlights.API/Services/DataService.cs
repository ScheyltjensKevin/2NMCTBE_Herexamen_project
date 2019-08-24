using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.API.Repositories;
using EasyFlights.Models;

namespace EasyFlights.API.Services
{
    public class DataService : IDataService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICountriesRepository _countriesRepository;
        private readonly IDepartureTRepository _departureTRepository;
        public DataService(ITicketRepository ticketRepository, IUserRepository userRepository, ICountriesRepository countriesRepository, IDepartureTRepository departureTRepository)
        {
            this._ticketRepository = ticketRepository;
            this._userRepository = userRepository;
            this._countriesRepository = countriesRepository;
            this._departureTRepository = departureTRepository;
        }

        #region tickets
        //Tickets
        public async Task<List<Tickets>> GetMyTickets(Guid userID)
        {
            return await _ticketRepository.GetMyTickets(userID);
        }

        public async Task<Tickets> GetTicketByID(Guid TicketID)
        {
            return await _ticketRepository.GetTicketByID(TicketID);
        }

        public async Task<List<Tickets>> GetTickets()
        {
            return await _ticketRepository.GetTickets();
        }

        public async Task<List<Tickets>> GetTicketsByDestDepT(string origin, string destination, DateTime time)
        {
            return await _ticketRepository.GetTicketsByCtry_Time(origin, destination, time);
        }

        public async Task<List<TicketAdmin>> GetAllUserTickets()
        {
            return await _ticketRepository.GetAllUserTickets();
        }
        #endregion

        #region users
        //Users
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUserByID(Guid id)
        {
            return await _userRepository.GetUserByID(id);

        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userRepository.GetUserByName(name);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();

        }

        public async Task ReserveTicket(UsersTickets uTickets)
        {
            await _userRepository.ReserveTicket(uTickets);

        }

        public async Task CancelTicket(UsersTickets uTickets)
        {
            await _userRepository.CancelTicket(uTickets);

        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);

        }




        #endregion

        #region Countries
        public async Task<List<Countries>> GetAllCountriesAsync()
        {
            return await _countriesRepository.GetAllCountriesAsync();
        }

        public async Task<Countries> GetCountryByIdAsync(Guid id)
        {
            return await _countriesRepository.GetCountryByIdAsync(id);
        }

        public async Task<Countries> GetCountryByName(string country)
        {
            return await _countriesRepository.GetCountryByName(country);
        }

        public async Task<List<Countries>> GetAllCountriesByTicketID(Guid TicketID)
        {
            return await _countriesRepository.GetAllCountriesByTicketID(TicketID);
        }
        #endregion

        #region departure times
        public async Task<List<DepartureTimes>> GetAllDepartureTimes()
        {
            return await _departureTRepository.GetAllDepartureTimes();
        }

        public async Task<DepartureTimes> GetDepartureTimeByID(Guid id)
        {
            return await _departureTRepository.GetDepartureTimeByID(id);
        }

        public async Task<DepartureTimes> GetDepartureTimesByTime(DateTime time)
        {
            return await _departureTRepository.GetDepartureTimesByTime(time);
        }

        public async Task<List<DepartureTimes>> GetDepartureTimesByTicketID(Guid TicketID)
        {
            return await _departureTRepository.GetDepartureTimesByTicketID(TicketID);
        }
        #endregion
    }
}
