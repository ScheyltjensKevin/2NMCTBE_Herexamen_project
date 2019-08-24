using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using EasyFlights.Models;
using EasyFlights.API.Services;


namespace EasyFlights.API.Controllers
{
    [Route("EasyFlights/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BonusController : ControllerBase
    {
        private readonly IDataService _dataService;
        List<BonusPoints> lst = new List<BonusPoints>();
        public BonusController(IDataService dataService)
        {
            _dataService = dataService;
            Get();
        }

        [HttpGet]
        public async Task<List<UsersBonusPointsDict>> Get()
        {
            List<UsersBonusPointsDict> lst = new List<UsersBonusPointsDict>();
            lst = await _dataService.GetAllHistoryBonusPoints();

            return lst;
        }

        [HttpGet("{name}")]
        public async Task<List<BonusPoints>> Get(string name)
        {
            User usr = new User();
            usr = await _dataService.GetUserByName(name);

            List<BonusPoints> bonus = new List<BonusPoints>();
            bonus = await _dataService.GetHistoryBonusPoints(usr);


            return bonus;
        }
    }
}