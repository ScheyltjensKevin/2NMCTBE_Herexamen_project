using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.API.Services;
using EasyFlights.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.API.Controllers
{
    [Route("EasyFlights/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly IDataService _dataService;


        List<User> lstUsers = new List<User>();
        public UsersController(UserContext context, IDataService dataService)
        {
            _context = context;
            this._dataService = dataService;
            Get();


            int i = 0;
            foreach (var user in lstUsers)
            {
                _context.Users.Add(lstUsers.ElementAt(i));
                _context.SaveChanges();
                i++;
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<List<User>> Get()
        {

            lstUsers = await _dataService.GetUsers();

            return lstUsers;

        }


        // GET: api/User/5
        [HttpGet("{name}")]
        public async Task<User> Get(string name)
        {
            User usr = new User();
            usr = await _dataService.GetUserByName(name);
            return usr;
        }


        // POST: api/User
        [HttpPost]
        public async Task Register([FromQuery] string email)
        {
            User usr = new User();

            if (email == null)
                throw new ArgumentNullException(nameof(email));
            else
                usr.Email = email;


            await _dataService.AddUser(usr);
        }

        [HttpPost("Reserve")]
        public async Task Reserve([FromQuery] Guid userID, [FromQuery] Guid ticketID, [FromQuery] Guid destinationID, [FromQuery] Guid departureID)
        {

            UsersTickets uTicket = new UsersTickets()
            {
                ID = Guid.NewGuid(),
                UserID = userID,
                TicketID = ticketID,
                DestinationID = destinationID,
                DepartureID = departureID
            };

            await _dataService.ReserveTicket(uTicket);

            BonusPoints points = new BonusPoints()
            {
                Id = Guid.NewGuid(),
                Points = 5,
                DateAquired = DateTime.Now
            };

            await _dataService.AddPoints(points);


            UserBonusPoints userBonus = new UserBonusPoints()
            {
                Id = Guid.NewGuid(),
                UserID = userID,
                PointID = points.Id
            };

            await _dataService.AddUserBonusPoints(userBonus);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Cancel")]
        public async void Cancel([FromQuery] Guid userID, [FromQuery] Guid ticketID, [FromQuery] Guid destinationID, [FromQuery] Guid departureID)
        {
            UsersTickets uTicket = new UsersTickets()
            {
                UserID = userID,
                TicketID = ticketID,
                DestinationID = destinationID,
                DepartureID = departureID
            };

            await _dataService.CancelTicket(uTicket);
        }

        [HttpDelete]
        public async void DeleteUser([FromQuery]string Email)
        {
            User user = await _dataService.GetUserByName(Email);
            await _dataService.DeleteUser(user.ID);
        }
    }
}
