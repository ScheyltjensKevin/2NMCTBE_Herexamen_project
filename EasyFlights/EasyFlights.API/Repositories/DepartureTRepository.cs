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
    public class DepartureTRepository : IDepartureTRepository
    {
        private readonly string connectionString;

        public DepartureTRepository(IConfiguration config)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
        }

        public async Task<List<DepartureTimes>> GetAllDepartureTimes()
        {
            List<DepartureTimes> lst = new List<DepartureTimes>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM DepartureTimes";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetData(reader);
                con.Close();
            }
            return lst;
        }

        public async Task<List<DepartureTimes>> GetDepartureTimesByTicketID(Guid TicketID)
        {
            List<DepartureTimes> lst = new List<DepartureTimes>();
            List<TicketDepartureTimes> lstDepTime = new List<TicketDepartureTimes>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * From TicketDepartureTimes Where TicketID = @id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@id", TicketID);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstDepTime = (await GetTicketDepartureData(reader));
                con.Close();

                foreach (var item in lstDepTime)
                {
                    lst.Add(await GetDepartureTimeByID(item.DepartureTimeID));

                }
            }

            return lst;
        }



        public async Task<DepartureTimes> GetDepartureTimeByID(Guid id)
        {
            DepartureTimes depTime = new DepartureTimes();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM DepartureTimes Where ID = @Id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                depTime = (await GetData(reader))[0];
                con.Close();
            }
            return depTime;
        }

        public async Task<DepartureTimes> GetDepartureTimesByTime(DateTime time)
        {
            DepartureTimes depTime = new DepartureTimes();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM DepartureTimes Where DepartureTime = @Time";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Time", time);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                depTime = (await GetData(reader))[0];
                con.Close();
            }
            return depTime;
        }


        private async Task<List<DepartureTimes>> GetData(SqlDataReader reader)
        {
            List<DepartureTimes> lst = new List<DepartureTimes>();

            try
            {
                while (await reader.ReadAsync())
                {
                    DepartureTimes dt = new DepartureTimes()
                    {
                        ID = (Guid)reader["ID"],
                        Time = Convert.ToDateTime(reader["DepartureTime"])
                    };


                    lst.Add(dt);
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



        private async Task<List<TicketDepartureTimes>> GetTicketDepartureData(SqlDataReader reader)
        {
            List<TicketDepartureTimes> lst = new List<TicketDepartureTimes>();

            try
            {
                while (await reader.ReadAsync())
                {
                    TicketDepartureTimes dt = new TicketDepartureTimes()
                    {
                        ID = (Guid)reader["ID"],
                        TicketID = (Guid)reader["TicketID"],
                        DepartureTimeID = (Guid)reader["DepartureTimeID"]
                    };


                    lst.Add(dt);
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

