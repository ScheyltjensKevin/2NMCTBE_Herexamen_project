using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using EasyFlights.Models.Logging;
using EasyFlights.Web.Models;
using EasyFlights.Web.ViewModels;
using EasyFlights.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace EasyFlights.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<TicketController> _logger;
        public SearchController(ILogger<TicketController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        HttpClient Client = new HttpClient();
        //get a series of dropdowns to enter parameters for the search.
        public async Task<IActionResult> Index()
        {
            User usr = await GetUser();
            List<TicketModel> lst = new List<TicketModel>();

            //create and empty ticket, it won't show on the page, but requires a ticket to initialize.
            TicketModel t = new TicketModel()
            {
                ID = Guid.NewGuid(),
                Country = "here",
                Available = 0,
                Destination = "this page",
                Departure = DateTime.Now,
                wayString = "one way",
                returnDate = "never",
                Bought = 0,
            };

            TryValidateModel(t);
            if (ModelState.IsValid)
                lst.Add(t);

            return View(lst);
        }

        //when the  form is submitted, get the tickets using the user defined parameters.
        public async Task<IActionResult> Search(IFormCollection collection)
        {
            User usr = await GetUser();
            // add the form data into a model for easy use. 
            Search s = new Search()
            {
                Origin = collection["origin"],
                Destination = collection["destination"],
                LeaveDate = collection["start"],
                ReturnDate = collection["end"],
                wayString = collection["retour"]
            };

            if (s.wayString == "one way")
                s.OneWay = true;
            else
                s.OneWay = false;
            s.AmountOfPassengers = Convert.ToInt16(collection["passengers"]);

            TryValidateModel(s);
            List<TicketModel> lst = new List<TicketModel>();

            if (ModelState.IsValid)
            {
                // url for the api 
                string url = "https://localhost:44355/EasyFlights/Tickets/SpecificTicket?origin=" + s.Origin + "&destination=" + s.Destination + "&leaveDate=" + s.LeaveDate + "&returnDate=" + s.ReturnDate + "&passengers=" + s.AmountOfPassengers + "&oneWay=" + s.OneWay;
                //get a list of tickets 
                var response = await Client.GetAsync(url);

                _logger.LogInformation("{Code}: Getting list of tickets defined by parameters given by user {userName}", LoggingEvents.ListItems, usr.Email);

                var result = await response.Content.ReadAsAsync<List<Tickets>>();
                if (result == null)
                {
                    _logger.LogWarning("{Code}: NO tickets FOUND by defined parameters {origin}, {destination}", LoggingEvents.ListItems, s.Origin, s.Destination);
                }
                //get tickets using the search parameters that the user defined. 
                lst = await GetReturnTickets(result, s.ReturnDate);
            }
            lst[0].Bought = 0;
            return View("Index", lst);
        }

        //"buy" a ticket and then return the same list of tickets using the user defined parameters. needs the parameters of the "bought" ticket and the parameters of the original search parameters defined by an 'o' in front.
        public async Task<IActionResult> Buy(string ticketID, string origin, string destination, string departure, string returnDate, string wayString, string oDeparture, string oReturnDate, string oOrigin, string oDestination)
        {

            User usr = await GetUser();
            string url = "https://localhost:44355/EasyFlights/Tickets/SpecificTicket?origin=" + oOrigin + "&destination=" + oDestination + "&leaveDate=" + oDeparture + "&returnDate=" + oReturnDate + "&passengers=" + 1 + "&oneWay=" + wayString;

            Countries c = await GetCountries(destination);
            DepartureTimes dp = await GetDepartures(departure);
            List<Tickets> lstT = await GetTickets(url);

            
            //gets the tickets that were searched for back so that one can order a second ticket with the same parameters.
            List<TicketModel> lst = new List<TicketModel>();
            _logger.LogInformation("{Code}: Changing list of tickets to conform to view needs", LoggingEvents.ListItems);
            lst = await GetReturnTickets(lstT, returnDate);
            if (lst == null)
            {
                _logger.LogWarning("{Code}: error when changing list to conform to view needs", LoggingEvents.ListItems);
            }

            // "buys" the ticket
            string urlR = "https://localhost:44355/EasyFlights/users/reserve?userID=" + usr.ID + "&ticketID=" + ticketID + "&destinationID=" + c.ID + "&departureID=" + dp.ID ;
            HttpContent Content = new StringContent("");
            var response = await Client.PostAsync(urlR, Content);
            var result = await response.Content.ReadAsAsync<List<TicketModel>>();
            response.EnsureSuccessStatusCode();
            lst[0].Bought = 1;
            string name = HttpContext.User.Identity.Name;
            ApplicationUser user = await _userManager.FindByEmailAsync(name);
            int totPoints = await GetBonusPoints(name);
            if (totPoints >= 15)
            {
                await AssignSuperUser(user);
            }
            else if(totPoints< 15)
                    await CheckCurrentRole(user);

            return View("index", lst);
        }

        //helpers
        private async Task CheckCurrentRole(ApplicationUser user)
        {
            if (await _userManager.IsInRoleAsync(user, "Admin")) { }
            else
            {
                await _userManager.AddToRoleAsync(user, "Super User");
            }
        }

        public async Task<User> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            string urlUserVer = "https://localhost:44355/EasyFlights/Users/" + userName;
            var response = await Client.GetAsync(urlUserVer);

            _logger.LogInformation("{Code}: Getting user {userName}", LoggingEvents.GetItem, userName);
            User usr = await response.Content.ReadAsAsync<User>();

            if (usr == null)
            {
                _logger.LogWarning("{Code}: GetUser {userName} NOT FOUND", LoggingEvents.GetItemNotFound, userName);
            }

            return usr;
        }

        public async Task<List<TicketModel>> GetReturnTickets(List<Tickets> lstTickets, string returnDate)
        {
            List<TicketModel> lst = new List<TicketModel>();

            string wString = "";
            if (lstTickets.Count() > 10)
                wString = "false";
            else
                wString = "true";


            for (int i = 0; i < lstTickets.Count(); i++)
            {
                TicketModel t = new TicketModel
                {
                    ID = lstTickets[i].ID,
                    Available = lstTickets[i].Available,
                    Country = lstTickets[i].Country,
                    Destination = lstTickets[i].Destination,
                    Departure = lstTickets[i].Departure,
                    Seat = lstTickets[i].Seat,
                    Price = lstTickets[i].Price,
                    wayString = wString,
                    returnDate = returnDate

                };

                TryValidateModel(t);
                if (ModelState.IsValid)
                    lst.Add(t);
            }

            return lst;
        }

        public async Task<Countries> GetCountries(string destination)
        {
            string urlCountries = "https://localhost:44355/EasyFlights/ID/countries?name=" + destination;
            //get the country ID 
            var responseD = await Client.GetAsync(urlCountries);
            _logger.LogInformation("{Code}: Getting id of country: {country}", LoggingEvents.GetItem, destination);
            var resultD = await responseD.Content.ReadAsAsync<Countries>();
            if (resultD == null)
            {
                _logger.LogWarning("{Code}: id of country: {country} NOT FOUND", LoggingEvents.GetItemNotFound, destination);
            }

            return resultD;
        }
        public async Task<DepartureTimes> GetDepartures(string departure)
        {
            string urlDepartures = "https://localhost:44355/EasyFlights/ID/departure?time=" + departure;
            //get the departure time ID
            var responseC = await Client.GetAsync(urlDepartures);
            _logger.LogInformation("{Code}: Getting id of departure: {departure}", LoggingEvents.GetItem, departure);
            var resultC = await responseC.Content.ReadAsAsync<DepartureTimes>();
            if (resultC == null)
            {
                _logger.LogWarning("{Code}: id of departure: {departure} NOT FOUND", LoggingEvents.GetItemNotFound, departure);
            }
            return resultC;
        }
        public async Task<List<Tickets>> GetTickets(string url)
        {
            //get a list of tickets
            var responseT = await Client.GetAsync(url);
            _logger.LogInformation("{Code}: Getting a list of tickets defined by parameters", LoggingEvents.ListItems);
            var resultT = await responseT.Content.ReadAsAsync<List<Tickets>>();
            if (resultT == null)
            {
                _logger.LogWarning("{Code}: NO tickets FOUND", LoggingEvents.ListItems);
            }
            return resultT;
        }

        private async Task AssignSuperUser(ApplicationUser user)
        {

            if (await _userManager.IsInRoleAsync(user, "Super user") || await _userManager.IsInRoleAsync(user, "Admin")) { }
            else
            {
                await _userManager.AddToRoleAsync(user, "Super User");
            }

        }

        private async Task<int> GetBonusPoints(string userName)
        {

            List<BonusPoints> lst = new List<BonusPoints>();

            string url = "https://localhost:44355/EasyFlights/Bonus/GetBonus/" + userName;
            var response = await Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<BonusPoints>>();
            lst = result;
            int total = 0;
            if (lst != null)
                total = lst.Count * 5;

            return total;
        }
    }
}