using EasyFlights.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.API.Repositories
{
    public interface ICountriesRepository
    {
        Task<List<Countries>> GetAllCountriesAsync();
        Task<Countries> GetCountryByIdAsync(Guid id);
        Task<Countries> GetCountryByName(string country);

        Task<List<Countries>> GetAllCountriesByTicketID(Guid TicketID);

    }
}