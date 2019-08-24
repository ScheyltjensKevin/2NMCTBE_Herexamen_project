using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyFlights.Web.Models;
using EasyFlights.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using EasyFlights.Models.Logging;


namespace EasyFlights.Web.Controllers
{
    public class HomeController : Controller
    {
        HttpClient Client = new HttpClient();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;

            if (userName != null)
            {

                string urlUserVer = "https://localhost:44355/EasyFlights/users/" + userName;
                //Get the user associated with the current logged in user

                var response = await Client.GetAsync(urlUserVer);
                _logger.LogInformation("{Code}: Getting user {userName}", LoggingEvents.GetItem, userName);
                var result = await response.Content.ReadAsAsync<User>();
                if (result == null)
                {
                    _logger.LogWarning("{Code}: User does NOT exist", LoggingEvents.GetItemNotFound, userName);
                }
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
