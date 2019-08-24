using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFlights.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.Web.Controllers
{
    public class UserController : Controller
    {
        //Get all the current registered users(only email and admin designation)
        public async  Task<IActionResult> Index()
        {
            string url = "https://localhost:44355/EasyFlights/users";

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<List<User>>();

            return View(result);
        }
    }
}