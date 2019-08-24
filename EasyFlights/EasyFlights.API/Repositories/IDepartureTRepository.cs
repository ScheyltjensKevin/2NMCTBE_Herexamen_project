using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyFlights.Models;

namespace EasyFlights.API.Repositories
{
    public interface IDepartureTRepository
    {
        Task<List<DepartureTimes>> GetAllDepartureTimes();
        Task<DepartureTimes> GetDepartureTimeByID(Guid id);
        Task<DepartureTimes> GetDepartureTimesByTime(DateTime time);
        Task<List<DepartureTimes>> GetDepartureTimesByTicketID(Guid TicketID);
    }
}