using EasyFlights.API.Models;
using EasyFlights.API.Services;
using EasyFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFlights.UnitTest.API_FakeServices
{
    public class DataServiceFake : IDataService
    {
        private readonly List<User> _users;
        public DataServiceFake()
        {
            _users = new List<User>()
            {
                new User(){ID = new Guid("945479ca-5b21-498e-a900-9af29955a319"), Email ="Docent@MCT"},
                new User(){ID = new Guid("79a30741-288f-458f-b890-fc1ff02b19c9"),Email = "Default@User"}
            };
        }

        public Task<BonusPoints> AddPoints(BonusPoints points)
        {
            throw new NotImplementedException();
        }

        public async Task<User> AddUser(User user)
        {
            User usr = new User();
            usr.ID = Guid.NewGuid();

            _users.Add(user);
            return usr;
        }

        public Task<UserBonusPoints> AddUserBonusPoints(UserBonusPoints userBonus)
        {
            throw new NotImplementedException();
        }

        public Task CancelTicket(UsersTickets uTicket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBonusPoints(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTickets(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Countries>> GetAllCountriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Countries>> GetAllCountriesByTicketID(Guid TicketID)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartureTimes>> GetAllDepartureTimes()
        {
            throw new NotImplementedException();
        }

        public Task<List<UsersBonusPointsDict>> GetAllHistoryBonusPoints()
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketAdmin>> GetAllUserTickets()
        {
            throw new NotImplementedException();
        }

        public Task<Countries> GetCountryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Countries> GetCountryByName(string country)
        {
            throw new NotImplementedException();
        }

        public Task<DepartureTimes> GetDepartureTimeByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartureTimes>> GetDepartureTimesByTicketID(Guid TicketID)
        {
            throw new NotImplementedException();
        }

        public Task<DepartureTimes> GetDepartureTimesByTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public Task<List<BonusPoints>> GetHistoryBonusPoints(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tickets>> GetMyTickets(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<Tickets> GetTicketByID(Guid TicketID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tickets>> GetTickets()
        {
            throw new NotImplementedException();
        }

        public Task<List<Tickets>> GetTicketsByDestDepT(string origin, string destination, DateTime time)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByID(Guid id)
        {
            return _users.Where(a => a.ID == id)
                .FirstOrDefault();
        }

        public async Task<User> GetUserByName(string name)
        {
            return _users.Where(a => a.Email == name)
                .FirstOrDefault();
        }

        public async Task<List<User>> GetUsers()
        {
            return _users;
        }

        public Task ReserveTicket(UsersTickets uTicket)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
