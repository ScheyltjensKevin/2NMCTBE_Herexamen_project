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
    }
}