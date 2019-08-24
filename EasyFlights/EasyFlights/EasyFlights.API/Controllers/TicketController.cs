using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.API.Repositories;
using EasyFlights.API.Services;
using EasyFlights.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFlights.API.Controllers
{
    [Route("EasyFlights/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly TicketContext _context;
        private readonly IDataService _dataService;
        public TicketController(TicketContext context, IDataService dataService)
        {
            _context = context;
            this._dataService = dataService;
        }

        // GET: api/ticket
        [HttpGet]
        public async Task<List<Tickets>> GetTickets()
        {
            List<Tickets> lstTickets = new List<Tickets>();

            lstTickets = (List<Tickets>)await _dataService.GetTickets();
            return lstTickets;
        }

        // GET: api/ticket/5
        [HttpGet("{id}", Name = "GetTicketsByID")]
        public async Task<Tickets> Get(Guid id)
        {
            Tickets tckt = new Tickets();
            tckt = await _dataService.GetTicketByID(id);
            return tckt;
        }

        [HttpGet("SpecificTicket", Name = "GetTicketsByDestDepT")]
        public async Task<List<Tickets>> GetTicketsByDestDepT(string origin, string destination, string leaveDate, string returnDate, int passengers, bool oneWay)
        {
            List<Tickets> lst = new List<Tickets>();
            DateTime leaveD = DateTime.Parse(leaveDate);
            DateTime returnD = DateTime.Parse(returnDate);
            int leaveHours = leaveD.Hour;
            leaveD = leaveD.AddHours(-leaveHours);

            if (oneWay != true)
            {
                lst = await _dataService.GetTicketsByDestDepT(origin, destination, leaveD);
                lst.AddRange(await _dataService.GetTicketsByDestDepT(destination, origin, returnD));
            }
            else
                lst = await _dataService.GetTicketsByDestDepT(origin, destination, leaveD);
            
            return lst;
        }

        [HttpGet("users", Name="GetAllUserTickets")]
        public async Task<List<TicketAdmin>> GetAllUserTickets()
        {
            List<TicketAdmin> lst = new List<TicketAdmin>();

            lst = await _dataService.GetAllUserTickets();
            return lst;
        }

        [HttpGet("MyTickets/{id}", Name = "GetMyTickets")]
        public async Task<List<Tickets>> GetMyTickets(Guid id)
        {
            List<Tickets> lstTickets = new List<Tickets>();
            lstTickets = await _dataService.GetMyTickets(id);
            return lstTickets;
        }
    }
}
