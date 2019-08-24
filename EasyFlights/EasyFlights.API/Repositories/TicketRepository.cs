using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.Models;
using Microsoft.Extensions.Configuration;

namespace EasyFlights.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly string connectionString;
        private readonly ICountriesRepository _countriesRepository;
        private readonly IDepartureTRepository _departureTRepository;

        public TicketRepository(IConfiguration config, ICountriesRepository countriesRepository, IDepartureTRepository departureTRepository)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");

            this._countriesRepository = countriesRepository;
            this._departureTRepository = departureTRepository;
        }

        public async Task<List<Tickets>> GetTickets()   //returns all the Tickets in the database
        {
            List<Tickets> lst = new List<Tickets>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "select * from Tickets";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetData(reader);
                con.Close();
            }
            return lst;
        }

        // check how to get an id and use a querry on that specific id(s)
        public async Task<List<Tickets>> GetMyTickets(Guid userID)    //return tickets which a user has reserved.
        {
            List<UsersTickets> lstUserTickets = new List<UsersTickets>();
            List<Tickets> lstTickets = new List<Tickets>();
            List<Guid> lstCtryIDs = new List<Guid>();
            List<Guid> lstDepTIDs = new List<Guid>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM UsersTickets Where UserID = @userID";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@userID", userID);


                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstUserTickets = (await GetUsersTicketsData(reader));
                con.Close();

                foreach (var item in lstUserTickets)
                {
                    lstCtryIDs.Add(item.DestinationID);
                    lstDepTIDs.Add(item.DepartureID);
                }

                for (int i = 0; i < lstUserTickets.Count(); i++)
                {
                    string sql2 = "SELECT * FROM Tickets Where ID = @ticketID";
                    SqlCommand cmd2 = new SqlCommand(sql2, con)
                    {
                        CommandType = CommandType.Text,
                    };
                    cmd2.Parameters.AddWithValue("@ticketID", lstUserTickets[i].TicketID);

                    con.Open();
                    SqlDataReader reader2 = await cmd2.ExecuteReaderAsync();
                    lstTickets.Add(await GetMyTicketData(reader2, lstCtryIDs[i], lstDepTIDs[i]));
                    con.Close();
                }


            }
            return lstTickets;
        }

        private async Task<Tickets> GetMyTicketData(SqlDataReader reader, Guid CtryID, Guid DepTID)
        {
            Tickets t = new Tickets();


            try
            {
                DepartureTimes depTimesX = new DepartureTimes();
                Countries ctryX = new Countries();

                while (await reader.ReadAsync())
                {
                    ctryX = await _countriesRepository.GetCountryByIdAsync(CtryID);
                    depTimesX = await _departureTRepository.GetDepartureTimeByID(DepTID);

                    t.ID = (Guid)reader["ID"];
                    t.Available = (int)reader["Available"];
                    t.Price = !Convert.IsDBNull(reader["Price"]) ? (int)reader["Price"] : 0;
                    Countries ctry = await _countriesRepository.GetCountryByIdAsync((Guid)reader["CountryID"]);
                    t.Country = ctry.CountryName;
                    t.Departure = depTimesX.Time;
                    t.Destination = ctryX.CountryName;
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
            return t;
        }

        public async Task<Tickets> GetTicketByID(Guid TicketID) // returns a ticket from which its Guid is given. 
        {
            Tickets tickets = new Tickets();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Tickets Where ID = @Id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Id", TicketID);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                tickets = (await GetData(reader))[0];
                con.Close();
            }
            return tickets;
        }

        public async Task<List<Tickets>> GetTicketsByCtry_Time(string origin, string destination, DateTime departureTime)
        {
            List<Tickets> lst = new List<Tickets>();

            Countries originCtry = await _countriesRepository.GetCountryByName(origin);
            Countries destinationCtry = await _countriesRepository.GetCountryByName(destination);

            bool noTime = false;
            DepartureTimes departureTimes = new DepartureTimes();
            List<Guid> lstdepTID = new List<Guid>();
            List<DepartureTimes> lstDepTimes = new List<DepartureTimes>();


            if (departureTime.Hour == 00)
            {
                noTime = true;
            }
            else
            {
                noTime = false;
            }


            if (noTime == true)
            {
                for (int i = 4; i <= 22;)
                {
                    DateTime times = departureTime.AddHours(i);

                    lstDepTimes.Add(await _departureTRepository.GetDepartureTimesByTime(times));
                    i += 2;

                }

                int ix = 0;

                foreach (var item in lstDepTimes)
                {
                    departureTimes = await _departureTRepository.GetDepartureTimesByTime(lstDepTimes[ix].Time);
                    ix += 1;
                    lstdepTID.Add(departureTimes.ID);

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sql = "Select * From Tickets Where CountryID = @Origin";
                        SqlCommand cmd = new SqlCommand(sql, con)
                        {
                            CommandType = System.Data.CommandType.Text,
                        };
                        cmd.Parameters.AddWithValue("@Origin", originCtry.ID);

                        con.Open();
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();
                        lst = await GetDataByDestDepT(reader, destinationCtry.ID, lstdepTID);
                        con.Close();
                    }

                }
                return lst;
            }
            else
            {
                DepartureTimes depTime = await _departureTRepository.GetDepartureTimesByTime(departureTime);
                List<Guid> lstdepTime = new List<Guid>
                {
                    depTime.ID
                };

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "Select * From Tickets Where CountryID = @Origin";
                    SqlCommand cmd = new SqlCommand(sql, con)
                    {
                        CommandType = System.Data.CommandType.Text,
                    };
                    cmd.Parameters.AddWithValue("@Origin", originCtry.ID);

                    con.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    lst = await GetDataByDestDepT(reader, destinationCtry.ID, lstdepTime);
                    con.Close();
                }
                return lst;
            }

        }

        public async Task<List<TicketAdmin>> GetAllUserTickets()
        {
            List<UsersTickets> lstUserTickets = new List<UsersTickets>();
            List<Tickets> lstTickets = new List<Tickets>();
            List<User> lstUsers = new List<User>();
            List<Guid> lstCtryIDs = new List<Guid>();
            List<Guid> lstDepTIDs = new List<Guid>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM UsersTickets";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstUserTickets = (await GetUsersTicketsData(reader));
                con.Close();

                foreach (var item in lstUserTickets)
                {
                    lstCtryIDs.Add(item.DestinationID);
                    lstDepTIDs.Add(item.DepartureID);
                }

                for (int i = 0; i < lstUserTickets.Count(); i++)
                {
                    string sql2 = "SELECT * FROM Tickets Where ID = @ticketID";
                    SqlCommand cmd2 = new SqlCommand(sql2, con)
                    {
                        CommandType = CommandType.Text,
                    };
                    cmd2.Parameters.AddWithValue("@ticketID", lstUserTickets[i].TicketID);

                    con.Open();
                    SqlDataReader reader2 = await cmd2.ExecuteReaderAsync();
                    lstTickets.Add(await GetMyTicketData(reader2, lstCtryIDs[i], lstDepTIDs[i]));
                    con.Close();
                }

                string sql3 = "SELECT * FROM Users";
                SqlCommand cmd3 = new SqlCommand(sql3, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();
                SqlDataReader reader3 = await cmd3.ExecuteReaderAsync();
                lstUsers = (await GetuserData(reader3));
                con.Close();

            }

            List<User> lstU = new List<User>();
            for (int i = 0; i < lstUsers.Count(); i++)
            {
                for (int ix = 0; ix < lstUserTickets.Count(); ix++)
                {
                    if (lstUsers[i].ID == lstUserTickets[ix].UserID)
                    {
                        if (lstU.Contains(lstUsers[i])) { }
                        else lstU.Add(lstUsers[i]);
                    }
                }
            }


            List<TicketAdmin> lst = new List<TicketAdmin>();

            for (int i = 0; i < lstTickets.Count(); i++)
            {
                TicketAdmin tA = new TicketAdmin()
                {
                    Available = lstTickets[i].Available,
                    Country = lstTickets[i].Country,
                    Departure = lstTickets[i].Departure,
                    Destination = lstTickets[i].Destination,
                    ID = lstTickets[i].ID,
                    Price = lstTickets[i].Price,
                    Seat = lstTickets[i].Seat
                };


                lst.Add(tA);
            }

            for (int i = 0; i < lstU.Count(); i++)
            {
                for (int ix = 0; ix < lstUserTickets.Count(); ix++)
                {
                    if (lstUserTickets[ix].UserID == lstU[i].ID && lstUserTickets[ix].TicketID == lstTickets[ix].ID)
                    {
                        lst[ix].Email = lstU[i].Email;
                    }
                }
            }


            return lst;
        }


        //DELETE
        public async Task DeleteTickets(Guid userID)
        {
            List<UsersTickets> lstUTickets = new List<UsersTickets>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sql = "Select * FROM UsersTickets Where UserID = @userID";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstUTickets = await GetUsersTicketsData(reader);
                con.Close();

                List<Tickets> lst = await GetMyTickets(userID);


                string sql1 = "DELETE FROM UsersTickets Where UserID = @userID";
                SqlCommand cmd1 = new SqlCommand(sql1, con)
                {
                    CommandType = CommandType.Text
                };
                cmd1.Parameters.AddWithValue("@userID", userID);
                con.Open();
                await cmd1.ExecuteNonQueryAsync();
                con.Close();


                for (int i = 0; i <= lst.Count; i++)
                {
                    string sql2 = "DELETE FROM Tickets Where ID = @ID";
                    SqlCommand cmd2 = new SqlCommand(sql2, con)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd2.Parameters.AddWithValue("@ID", lst[i].ID);
                    con.Open();
                    await cmd2.ExecuteNonQueryAsync();
                    con.Close();
                }
            }
        }



        private async Task<List<User>> GetuserData(SqlDataReader reader)
        {
            List<User> Usr = new List<User>();

            try
            {
                while (await reader.ReadAsync())
                {
                    User u = new User()
                    {
                        ID = (Guid)reader["ID"],
                        Email = !Convert.IsDBNull(reader["Email"]) ? (string)reader["Email"] : ""
                    };


                    Usr.Add(u);
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
            return Usr;

        }
        private async Task<List<Tickets>> GetDataByDestDepT(SqlDataReader reader, Guid destinationID, List<Guid> depTimeID)
        {
            List<Tickets> lst = new List<Tickets>();

            try
            {
                List<Countries> lstCtrys = new List<Countries>();
                List<DepartureTimes> lstDepTimes = new List<DepartureTimes>();

                while (await reader.ReadAsync())
                {
                    Tickets t = new Tickets
                    {
                        ID = (Guid)reader["ID"]
                    };

                    //anything below this need t.ID to not be a Guid.empty
                    Countries lstctry = new Countries();
                    lstctry = await _countriesRepository.GetCountryByIdAsync(destinationID);

                    DateTime depTime = DateTime.Now;

                    foreach (var item in depTimeID)
                    {
                        lstDepTimes.Add(await _departureTRepository.GetDepartureTimeByID(item));
                    }

                    Countries ctry = await _countriesRepository.GetCountryByIdAsync((Guid)reader["CountryID"]);

                    foreach (var itemc in lstDepTimes)
                    {
                        depTime = itemc.Time;

                        Tickets tx = new Tickets()
                        {
                            ID = (Guid)reader["ID"],
                            Available = (int)reader["Available"],
                            Price = !Convert.IsDBNull(reader["Price"]) ? (int)reader["Price"] : 0,
                            Destination = lstctry.CountryName,
                            Country = ctry.CountryName,

                            Departure = depTime
                        };
                        lst.Add(tx);
                    }
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

        private async Task<List<UsersTickets>> GetUsersTicketsData(SqlDataReader reader)
        {
            List<UsersTickets> lst = new List<UsersTickets>();

            try
            {
                while (await reader.ReadAsync())
                {
                    UsersTickets uTicket = new UsersTickets()
                    {
                        ID = (Guid)reader["ID"],
                        UserID = (Guid)reader["UserID"],
                        TicketID = (Guid)reader["TicketID"],
                        DestinationID = (Guid)reader["DestinationID"],
                        DepartureID = (Guid)reader["DepartureID"],
                    };


                    lst.Add(uTicket);
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

        private async Task<List<Tickets>> GetData(SqlDataReader reader)     //SQL helper
        {
            List<Tickets> lst = new List<Tickets>();

            try
            {
                List<Countries> lstCtrys = new List<Countries>();
                List<DepartureTimes> lstDepTimes = new List<DepartureTimes>();

                while (await reader.ReadAsync())
                {
                    Tickets t = new Tickets
                    {
                        //execute this first else the other  code wont work
                        ID = (Guid)reader["ID"]
                    };
                    //only needs to run once per row in the reader
                    Countries ctry = await _countriesRepository.GetCountryByIdAsync((Guid)reader["CountryID"]);

                    //anything below this need to have t.ID not be a Guid.empty
                    List<string> lstCtryNames = new List<string>();
                    //we need these to make the for loops work
                    lstCtrys = await _countriesRepository.GetAllCountriesByTicketID(t.ID);
                    lstDepTimes = await _departureTRepository.GetDepartureTimesByTicketID(t.ID);

                    string Cname = "";

                    //needs the countries from 
                    for (int i = 0; i < lstCtrys.Count(); i++)
                    {
                        Cname = lstCtrys[i].CountryName;
                        t.Destination = Cname;

                        for (int ix = 0; ix < lstDepTimes.Count(); ix++)
                        {
                            Tickets tx = new Tickets()
                            {
                                ID = (Guid)reader["ID"],
                                Available = (int)reader["Available"],
                                Price = !Convert.IsDBNull(reader["Price"]) ? (int)reader["Price"] : 0,
                                Country = ctry.CountryName,
                                Destination = Cname,
                                Departure = lstDepTimes[ix].Time
                            };


                            lst.Add(tx);
                        }
                    }
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
