using EasyFlights.API.Models;
using EasyFlights.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.API.Repositories
{
    public interface IUserRepository
    {

        //Get
        Task<List<User>> GetUsers();    // tested, but needs html/css to be shown still
        Task<User> GetUserByID(Guid id);    // tested, but needs html/css to be shown still
        Task<User> GetUserByName(string name);

        //Post
        Task<User> AddUser(User user);  // untested
        //Put
        Task<User> UpdateUser(User user);   // untested
        Task ReserveTicket(UsersTickets uTicket); // untested
        Task CancelTicket(UsersTickets uTicket);   // untested
        //Delete
        Task DeleteUser(Guid id);   // untested
    }
}