using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyFlights.Web.Models;
using EasyFlights.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace EasyFlights.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;

            if(userName != null)
            {
                string urlUserVer = "https://localhost:44355/EasyFLights/Users/" + userName;

                //Get the user associated with the current logged in user
                var client = new HttpClient();
                var response = await client.GetAsync(urlUserVer);
                var result = await response.Content.ReadAsAsync<User>();

                return View(result);
            }
            else
            {
                return View(new User());
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
