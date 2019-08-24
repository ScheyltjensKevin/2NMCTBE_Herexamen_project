using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models.Logging;
using EasyFlights.Web.ViewModels;
using EasyFlights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyFlights.Web.Data;
using Microsoft.AspNetCore.Identity;

namespace EasyFlights.Web.Controllers
{
    public class BonusController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public BonusController(ILogger<TicketController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }

        HttpClient Client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;
            List<BonusPoints> lst = new List<BonusPoints>();

            string url = "https://localhost:44355/EasyFlights/Bonus/" + userName;
            var response = await Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<BonusPoints>>();
            lst = result;

            ApplicationUser user = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
            int t = 0;
            if (lst != null)
            {
                t = lst.Count * 5;
                if (t >= 15)
                {
                    await AssignSuperUser(user);
                }
                else if(t<15)
                    await CheckCurrentRole(user);
            }

            return View("Index", lst);
        }

        private async Task CheckCurrentRole(ApplicationUser user)
        {
            if (await _userManager.IsInRoleAsync(user, "Admin")) { }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Super User");
            }
        }

        public async Task<IActionResult> UsersBonusPoints()
        {
            List<UsersBonusPointsDict> dictVM = new List<UsersBonusPointsDict>();

            string url = "https://localhost:44355/EasyFlights/Bonus";
            var response = await Client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<UsersBonusPointsDict>>();
            dictVM = result;

            
            return View("UsersBonusPoints", dictVM);
        }


        //helpers
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

        private async Task AssignSuperUser(ApplicationUser user)
        {

            if (await _userManager.IsInRoleAsync(user, "Super user") || await _userManager.IsInRoleAsync(user, "Admin")) { }
            else
            {
                await _userManager.AddToRoleAsync(user, "Super User");
                
            }

        }
    }
}