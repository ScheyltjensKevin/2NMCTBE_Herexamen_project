using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using EasyFlights.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public TicketController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        HttpClient Client = new HttpClient();
        //Get the tickets of the current user
        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;

            if (userName != null)
            {
                User usr = await GetUser();
                Guid userID = usr.ID;
                List<TicketAdmin> lst = await GetMyTickets(userID);
                lst[0].Administrator = usr.Administrator;
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

            HttpContent Content = new StringContent("");
            var response = await Client.DeleteAsync(url);

            List<TicketAdmin> lst = await GetMyTickets(lstID[0]);
            return View("Index", lst);
        }
        //Get all Tickets that users have "bought"
        public async Task<IActionResult> UserTickets()
        {
            string userName = HttpContext.User.Identity.Name;

            if (userName != null)
            {
                User usr = await GetUser();

                if (usr.Administrator == 1)
                {
                    List<TicketAdmin> lst = await GetAllUserTickets();
                    return View("UserTickets", lst);
                }
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
            var response = await Client.DeleteAsync(url);

            User usr = await GetUser();
            string userName = HttpContext.User.Identity.Name;


            if (userName != null)
            {
                if (usr.Administrator == 1)
                {
                    List<TicketAdmin> lst = await GetAllUserTickets();
                    return View("UserTickets", lst);
                }
            }
            List<TicketAdmin> lst1 = new List<TicketAdmin>();
            return View("UserTickets", lst1);
        }


        //Helpers
        public async Task<List<Guid>> GetIDS(string username, string dest, DateTime dep)
        {
            List<Guid> lst = new List<Guid>();

            string urlUserVer = "https://localhost:44355/EasyFLights/Users/" + username;
            string urlCountries = "https://localhost:44355/EasyFLights/ID/countries?name=" + dest;
            string urlDepartures = "https://localhost:44355/EasyFLights/ID/departure?time=" + dep;

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
            string urlAllUserTickets = "https://localhost:44355/EasyFlights/tickets/users/";

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
            string urlUserVer = "https://localhost:44355/EasyFLights/Users/" + userName;
            var response = await Client.GetAsync(urlUserVer);
            User usr = await response.Content.ReadAsAsync<User>();

            return usr;
        }
    }
}