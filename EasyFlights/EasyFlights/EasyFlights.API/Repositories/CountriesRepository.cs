using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.Models;
using Microsoft.Extensions.Configuration;

namespace EasyFlights.API.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly string connectionString;

        public CountriesRepository(IConfiguration config)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
        }

        public async Task<List<Countries>> GetAllCountriesAsync()
        {
            List<Countries> lst = new List<Countries>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Countries";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetData(reader);
                con.Close();
            }
            return lst;
        }

       public async Task<List<Countries>> GetAllCountriesByTicketID(Guid TicketID)
        {
            List<TicketDestination> lst = new List<TicketDestination>();
            List<Countries> lstCtry = new List<Countries>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * From TicketDestinations Where TicketID = @id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@id", TicketID);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetTicketDestData(reader);
                con.Close();

                foreach (var item in lst)
                {
                    lstCtry.Add(await GetCountryByIdAsync(item.CountryID));

                }
            }
            return lstCtry;
        }

        public async Task<Countries> GetCountryByIdAsync(Guid id)
        {
            Countries ctry = new Countries();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Countries Where ID = @Id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                ctry = (await GetData(reader))[0];
                con.Close();
            }
            return ctry;
        }

        public async Task<Countries> GetCountryByName(string country)
        {
            Countries Ctry = new Countries();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "Select * From Countries Where Country = @Origin";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Origin", country);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                Ctry = (await GetData(reader))[0];
                con.Close();
            }
            return Ctry;
        }


        private async Task<List<Countries>> GetData(SqlDataReader reader)
        {
            List<Countries> lst = new List<Countries>();

            try
            {
                while (await reader.ReadAsync())
                {
                    Countries c = new Countries();
                    c.ID = (Guid)reader["ID"];
                    c.CountryCode = !Convert.IsDBNull(reader["CountryCode"]) ? (string)reader["CountryCode"] : "";
                    c.CountryName = !Convert.IsDBNull(reader["Country"]) ? (string)reader["Country"] : "";

                    lst.Add(c);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader.Close();
            }
            return lst;
        }


        private async Task<List<TicketDestination>> GetTicketDestData(SqlDataReader reader)
        {
            List<TicketDestination> lst = new List<TicketDestination>();

            try
            {
                while (await reader.ReadAsync())
                {
                    TicketDestination c = new TicketDestination();
                    c.ID = (Guid)reader["ID"];
                    c.TicketID = (Guid)reader["TicketID"];
                    c.CountryID = (Guid)reader["CountryID"];

                    lst.Add(c);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader.Close();
            }
            return lst;
        }

    }
}
