using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using EasyFlights.Web.ViewModels;
using EasyFlights.Models.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using EasyFlights.Web.Data;
using Microsoft.AspNetCore.Identity;

namespace EasyFlights.Web.Controllers
{
    public class UserController : Controller
    {
        HttpClient Client = new HttpClient();

        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ILogger<UserController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        //Get all the current registered users(only email and role designation)
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("{Code}: Getting users", LoggingEvents.GetItem);

            string url = "https://localhost:44355/EasyFlights/users";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<User>>();
            if (result == null)
            {
                _logger.LogWarning("{Code}: GetUsers", LoggingEvents.GetItemNotFound);
            }

            List<UserVM> lst = await CreateUserVM(result);


            return View(lst);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(string email, string role, int points)
        {

            string url = "https://localhost:44355/EasyFlights/users?email=" + email;

            var client = new HttpClient();

            UserVM vm = new UserVM()
            {
                Email = email,
                Role = role,
                TotalPoints = points
            };
            ApplicationUser usr = await _userManager.FindByEmailAsync(vm.Email);
            if (await _userManager.IsInRoleAsync(usr, "User"))
            {
                await _userManager.RemoveFromRoleAsync(usr, "User");
                await _userManager.DeleteAsync(usr);
            }
            else if (await _userManager.IsInRoleAsync(usr, "Super User"))
            {
                await _userManager.RemoveFromRoleAsync(usr, "Super User");
                await _userManager.DeleteAsync(usr);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(usr, "Admin");
                await _userManager.DeleteAsync(usr);
            }
            var response = await client.DeleteAsync(url);

            List<User> users = await GetUsers();
            List<UserVM> lst = await CreateUserVM(users);

            return View("Index", lst);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeAdmin(string email, string role, int points)
        {
            string url = "https://localhost:44355/EasyFlights/users?email=" + email;

            var client = new HttpClient();

            UserVM vm = new UserVM()
            {
                Email = email,
                Role = role,
                TotalPoints = points
            };
            ApplicationUser usr = await _userManager.FindByEmailAsync(vm.Email);

            await _userManager.RemoveFromRoleAsync(usr, role);
            await _userManager.AddToRoleAsync(usr, "Admin");


            List<User> users = await GetUsers();
            List<UserVM> lst = await CreateUserVM(users);
            return View("Index", lst);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakeUser(string email, string role, int points)
        {
            string url = "https://localhost:44355/EasyFlights/users?email=" + email;

            var client = new HttpClient();

            UserVM vm = new UserVM()
            {
                Email = email,
                Role = role,
                TotalPoints = points
            };
            ApplicationUser usr = await _userManager.FindByEmailAsync(vm.Email);

            await _userManager.RemoveFromRoleAsync(usr, role);
            await _userManager.AddToRoleAsync(usr, "User");


            List<User> users = await GetUsers();
            List<UserVM> lst = await CreateUserVM(users);
            return View("Index", lst);
        }


        private async Task<List<User>> GetUsers()
        {
            string url = "https://localhost:44355/EasyFlights/users";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<User>>();
            return result;
        }

        private async Task<List<UserVM>> CreateUserVM(List<User> result)
        {
            List<UserVM> lst = new List<UserVM>();
            foreach (var item in result)
            {
                int points = await GetBonusPoints(item.Email);
                ApplicationUser user = await _userManager.FindByEmailAsync(item.Email);
                string role = "";
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    role = "Admin";
                }
                else if (await _userManager.IsInRoleAsync(user, "Super User"))
                {
                    role = "Super User";
                }
                else
                {
                    role = "User";
                }

                UserVM usrVM = new UserVM
                {
                    Email = item.Email,
                    Role = role,
                    TotalPoints = points,
                };
                lst.Add(usrVM);
            }
            return lst;
        }
        private async Task<int> GetBonusPoints(string userName)
        {
            List<BonusPoints> lst = new List<BonusPoints>();

            string url = "https://localhost:44355/EasyFlights/Bonus/" + userName;
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