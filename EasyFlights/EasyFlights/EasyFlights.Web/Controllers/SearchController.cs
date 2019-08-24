using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using EasyFlights.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.Web.Controllers
{
    public class SearchController : Controller
    {
        HttpClient Client = new HttpClient();
        //get a series of dropdowns to enter parameters for the search.
        public async Task<IActionResult> Index()
        {
            User usr = await GetUser();

            TicketModel t = new TicketModel()
            {
                ID = Guid.Empty,
                Country = "",
                Available = 0,
                Administrator = usr.Administrator,
            };
            List<TicketModel> lst = new List<TicketModel>();
            lst.Add(t);

            return View(lst);
        }
        //when the  form is submitted, get the tickets using the user defined parameters.
        public async Task<IActionResult> Search(IFormCollection collection)
        {
            User usr = await GetUser();
            // add the form data into a model for easy use. 
            Search search = new Search();
            search.Origin = collection["origin"];
            search.Destination = collection["destination"];
            search.LeaveDate = collection["start"];
            search.ReturnDate = collection["end"];
            search.wayString = collection["retour"];
            if (search.wayString == "one way")
                search.OneWay = true;
            else
                search.OneWay = false;
            search.AmountOfPassengers = Convert.ToInt16(collection["passengers"]);
            // url for the api 
            string url = "https://localhost:44355/EasyFlights/Tickets/SpecificTicket?origin=" + search.Origin + "&destination=" + search.Destination + "&leaveDate=" + search.LeaveDate + "&returnDate=" + search.ReturnDate + "&passengers=" + search.AmountOfPassengers + "&oneWay=" + search.OneWay;
            //get a list of tickets 
            var response = await Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<Tickets>>();

            //get tickets using the search parameters that the user defined. 
            List<TicketModel> lst = new List<TicketModel>();
            lst = await GetTickets(result, usr.Administrator, search.ReturnDate);

            return View("Index", lst);
        }
        //"buy" a ticket and then return the same list of tickets using the user defined parameters. needs the parameters of the "bought" ticket and the parameters of the original search parameters defined by an 'o' in front.
        public async Task<IActionResult> Buy(string ticketID, string origin, string destination, string departure, string returnDate, string wayString, string oDeparture, string oReturnDate, string oOrigin, string oDestination)
        {

            User usr = await GetUser();

            string urlCountries = "https://localhost:44355/EasyFLights/ID/countries?name=" + destination;
            string urlDepartures = "https://localhost:44355/EasyFLights/ID/departure?time=" + departure;
            string url = "https://localhost:44355/EasyFlights/Tickets/SpecificTicket?origin=" + oOrigin + "&destination=" + oDestination + "&leaveDate=" + oDeparture + "&returnDate=" + oReturnDate + "&passengers=" + 1 + "&oneWay=" + wayString;

            //get the country ID 
            var responseD = await Client.GetAsync(urlCountries);
            var resultD = await responseD.Content.ReadAsAsync<Countries>();
            //get the departure time ID
            var responseC = await Client.GetAsync(urlDepartures);
            var resultC = await responseC.Content.ReadAsAsync<DepartureTimes>();
            //get a list of tickets
            var responseT = await Client.GetAsync(url);
            var resultT = await responseT.Content.ReadAsAsync<List<Tickets>>();

            //gets the tickets that were searched for back so that one can order a second ticket with the same parameters.
            List<TicketModel> lst = new List<TicketModel>();
            lst = await GetTickets(resultT, usr.Administrator, returnDate);

            // "buys" the ticket
            string urlR = "https://localhost:44355/EasyFlights/users/reserve?userID=" + usr.ID + "&ticketID=" + ticketID + "&destinationID=" + resultD.ID + "&departureID=" + resultC.ID;
            HttpContent Content = new StringContent("");
            var response = await Client.PostAsync(urlR, Content);
            var result = await response.Content.ReadAsAsync<List<TicketModel>>();

            return View("index", lst);
        }

        //helpers
        public async Task<User> GetUser()
        {
            string userName = HttpContext.User.Identity.Name;
            string urlUserVer = "https://localhost:44355/EasyFLights/Users/" + userName;
            var response = await Client.GetAsync(urlUserVer);
            User usr = await response.Content.ReadAsAsync<User>();

            return usr;
        }

        public async Task<List<TicketModel>> GetTickets(List<Tickets> lstTickets, int admin, string returnDate)
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
                    returnDate = returnDate,
                    Administrator = admin,

                };

                lst.Add(t);
            }

            return lst;
        }
    }
}