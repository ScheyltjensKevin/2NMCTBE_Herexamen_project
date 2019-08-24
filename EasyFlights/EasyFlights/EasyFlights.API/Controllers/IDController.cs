using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Services;
using EasyFlights.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.API.Controllers
{
    [Route("EasyFlights/ID")]
    [ApiController]
    public class IDController : ControllerBase
    {
        private readonly IDataService _dataService;
        public IDController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("countries", Name = "GetCountryByName")]
        public async Task<Countries> GetCountryByName([FromQuery]string name)
        {
            Countries ctry = new Countries();

            ctry = await _dataService.GetCountryByName(name);
            return ctry;
        }

        [HttpGet("countries/{id}",Name ="GetCountryByID")]
        public async Task<Countries> GetCountryByID(Guid id)
        {
            Countries ctry = new Countries();
            ctry = await _dataService.GetCountryByIdAsync(id);
            return ctry;
        }

        [HttpGet("departure", Name = "GetDepartureTByTime")]
        public async Task<DepartureTimes> GetDepartureTByTime([FromQuery]string time)
        {
            DepartureTimes depTime = new DepartureTimes();
            DateTime dTime = DateTime.Parse(time);

            depTime = await _dataService.GetDepartureTimesByTime(dTime);
            return depTime;
        }

        [HttpGet("/departure/{id}", Name = "GetDepartureTByID")]
        public async Task<DepartureTimes> GetDepartureTByID(Guid id)
        {
            DepartureTimes depTime = new DepartureTimes();
            depTime = await _dataService.GetDepartureTimeByID(id);
            return depTime;
        }

    }
}