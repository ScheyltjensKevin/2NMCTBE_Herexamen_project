using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using EasyFlights.Models.Logging;
using EasyFlights.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace EasyFlights.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public TicketController(SignInManager<ApplicationUser> signInManager, ILogger<TicketController> logger)
        {
            _signInManager = signInManager;

            _logger = logger;

        }

        HttpClient Client = new HttpClient();
        //Get the tickets of the current user
        public async Task<IActionResult> Index()
        {

            string userName = HttpContext.User.Identity.Name;
            User usr = await GetUser();

            if (userName != null)
            {
                Guid userID = usr.ID;
                _logger.LogInformation("{code}: Get Tickets associated with user", LoggingEvents.ListItems, userName);

                List<TicketAdmin> lst = await GetMyTickets(userID);
                if (lst == null)
                {
                    _logger.LogWarning("{code}: Tickets from user {userName} NOT FOUND", LoggingEvents.ListItems, userName);
                }

                return View("Index", lst);

            }
            List<TicketAdmin> lst1 = new List<TicketAdmin>();
            return View(lst1);
        }
        // Cancel a ticket from yourself
        public async Task<IActionResult> Cancel(string destination, string departure, string ticketID)
        {

            string userName = HttpContext.User.Identity.Name;
            DateTime dep = DateTime.Parse(departure);
            List<Guid> lstID = await GetIDS(userName, destination, dep);

            // make the url to cancel the ticket
            string url = "https://localhost:44355/EasyFlights/users/Cancel?userID=" + lstID[0] + "&ticketID=" + ticketID + "&destinationID=" + lstID[1] + "&departureID=" + lstID[2];

            _logger.LogInformation("{code}: Deleted Ticket {ticketID}", LoggingEvents.DeleteItem, ticketID);

            HttpContent Content = new StringContent("");
            var response = await Client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("{code}: UNSUCCESFULL deletion of Ticket {ticketID}", LoggingEvents.DeleteItem, ticketID);
            }

            _logger.LogInformation("{code}: Getting tickets associated with user", LoggingEvents.ListItems, userName);

            List<TicketAdmin> lst = await GetMyTickets(lstID[0]);

            if (lst == null)
            {
                _logger.LogWarning("{code}: Tickets from user {userName} NOT FOUND", LoggingEvents.ListItems, userName);
            }

            return View("Index", lst);
        }
        //Get all Tickets that users have "bought"
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserTickets()
        {
            string userName = HttpContext.User.Identity.Name;

            if (userName != null)
            {
                User usr = await GetUser();


                _logger.LogInformation("{code}: Getting tickets associated with user {userName}", LoggingEvents.ListItems, userName);
                List<TicketAdmin> lst = await GetAllUserTickets();
                if (lst == null)
                {
                    _logger.LogWarning("{code}: Tickets from user {userName} NOT FOUND", LoggingEvents.ListItems, userName);
                }
                return View("UserTickets", lst);

            }
            List<TicketAdmin> lst1 = new List<TicketAdmin>();
            return View(lst1);
        }
        //Admin can delete a ticket for a user
        public async Task<IActionResult> Delete(Guid id, string dest, DateTime dep, string user)
        {
            List<Guid> lstID = await GetIDS(user, dest, dep);

            // make the url to cancel the ticket
            string url = "https://localhost:44355/EasyFlights/users/Cancel?userID=" + lstID[0] + "&ticketID=" + id + "&destinationID=" + lstID[1] + "&departureID=" + lstID[2];

            //cancel the ticket using the url, give a empty content with it since all parameters are in header.
            HttpContent Content = new StringContent("");

            _logger.LogInformation("{code}: Deleting a ticket from user {user}", LoggingEvents.DeleteItem, user);

            var response = await Client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("{code}: could NOT delete ticket from user {user}", LoggingEvents.DeleteItem, user);
            }

            User usr = await GetUser();
            string userName = HttpContext.User.Identity.Name;


            if (userName != null)
            {

                _logger.LogInformation("{code}: Getting tickets from all users", LoggingEvents.ListItems);

                List<TicketAdmin> lst = await GetAllUserTickets();

                if (lst == null)
                {
                    _logger.LogWarning("{code}: tickets from all users NOT FOUND", LoggingEvents.ListItems);
                }
                return View("UserTickets", lst);

            }
            List<TicketAdmin> lst1 = new List<TicketAdmin>();
            return View("UserTickets", lst1);
        }



        //Helpers
        public async Task<List<Guid>> GetIDS(string username, string dest, DateTime dep)
        {
            List<Guid> lst = new List<Guid>();
            string urlUserVer = "https://localhost:44355/EasyFlights/Users/" + username;
            string urlCountries = "https://localhost:44355/EasyFlights/ID/countries?name=" + dest;
            string urlDepartures = "https://localhost:44355/EasyFlights/ID/departure?time=" + dep;

            //Get the country
            var responseC = await Client.GetAsync(urlCountries);
            var resultC = await responseC.Content.ReadAsAsync<Countries>();
            //Get the departure time
            var responseD = await Client.GetAsync(urlDepartures);
            var resultD = await responseD.Content.ReadAsAsync<DepartureTimes>();
            //Get the user associated with the selected ticket to delete
            var responseU = await Client.GetAsync(urlUserVer);
            var resultU = await responseU.Content.ReadAsAsync<User>();

            lst.Add(resultU.ID);
            lst.Add(resultC.ID);
            lst.Add(resultD.ID);

            return lst;
        }

        public async Task<List<TicketAdmin>> GetAllUserTickets()
        {

            string urlAllUserTickets = "https://localhost:44355/EasyFlights/tickets/users";

            List<TicketAdmin> lst = new List<TicketAdmin>();

            //get the tickets associated with the user
            var response2 = await Client.GetAsync(urlAllUserTickets);
            if (response2.IsSuccessStatusCode)
            {
                lst = await response2.Content.ReadAsAsync<List<TicketAdmin>>();
            }
            else
            {
                lst = new List<TicketAdmin>();
            }

            return lst;
        }

        public async Task<List<TicketAdmin>> GetMyTickets(Guid userID)
        {
            string urlMyTickets = "https://localhost:44355/EasyFlights/tickets/Mytickets/" + userID;

            List<TicketAdmin> lst = new List<TicketAdmin>();

            //get the tickets associated with the user
            var response2 = await Client.GetAsync(urlMyTickets);
            if (response2.IsSuccessStatusCode)
            {
                lst = await response2.Content.ReadAsAsync<List<TicketAdmin>>();
            }
            else
            {
                lst = new List<TicketAdmin>();
            }

            return lst;
        }

        public async Task<User> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            string urlUserVer = "https://localhost:44355/EasyFlights/Users/" + userName;
            var response = await Client.GetAsync(urlUserVer);

            _logger.LogInformation("{code}: Get User", LoggingEvents.GetItem);
            User usr = await response.Content.ReadAsAsync<User>();
            if (usr == null)
            {
                _logger.LogWarning("{code}: Get user {userName}", LoggingEvents.GetItemNotFound, userName);
            }
            return usr;
        }
    }
}