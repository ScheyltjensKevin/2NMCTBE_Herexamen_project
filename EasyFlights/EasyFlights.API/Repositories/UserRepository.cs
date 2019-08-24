using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyFlights.API.Models;
using EasyFlights.Models;
using Microsoft.Extensions.Configuration;

namespace EasyFlights.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(IConfiguration config)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
        }

        #region Get
        public async Task<List<User>> GetUsers()     //returns all the users currently within the database.
        {
            List<User> lst = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetData(reader);
                con.Close();
            }
            return lst;
        }

        public async Task<User> GetUserByID(Guid id)    // gives the data of a user back when requesting via an existing ID
        {
            User usr = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users Where ID = @Id";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                usr = (await GetData(reader)).First();
                con.Close();
            }
            return usr;
        }

        public async Task<User> GetUserByName(string name)
        {
            User usr = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@Email", name);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                usr = (await GetData(reader)).First();
                con.Close();
            }
            return usr;
        }
        #endregion

        #region Post
        public async Task<User> AddUser(User user)  //Adds a user to the database, Giving it a Guid and the entered data.
        {
            User usr = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "Insert into Users(ID, Email)";
                sql += " Values(@ID, @Email)";

                SqlCommand cmd = new SqlCommand(sql, con);

                Guid guid = Guid.NewGuid();
                cmd.Parameters.AddWithValue("@ID", guid);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();

            }

            return user;
        }

        public async Task ReserveTicket(UsersTickets uTickets) // gives the user the ticketID and changes the AvailableID of the Ticket to a new Guid wich indicates it's "taken" status.
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO UsersTickets(ID, UserID, TicketID, DestinationID, DepartureID) Values(@id, @userID, @ticketID, @destinationID, @departureID)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", uTickets.ID);
                cmd.Parameters.AddWithValue("@userID", uTickets.UserID);
                cmd.Parameters.AddWithValue("@ticketID", uTickets.TicketID);
                cmd.Parameters.AddWithValue("@destinationID", uTickets.DestinationID);
                cmd.Parameters.AddWithValue("@departureID", uTickets.DepartureID);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }
        #endregion

        #region Put
        public async Task<User> UpdateUser(User user)   //Updates the data of a user in the database
        {
            User usr = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Users SET Email = @Email Where ID = @Id ";

                SqlCommand cmd = new SqlCommand(sql, con);
                if (user.Email != null)
                {
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Id", user.ID);
                }

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                return user;
            }
        }
        #endregion

        #region Delete
        public async Task DeleteUser(Guid id)   //Deletes a user from the database
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Users WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }
        public async Task CancelTicket(UsersTickets uTickets)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "DELETE From UsersTickets WHERE TicketID = @ticketID AND UserID = @userID AND DestinationID = @destinationID AND DepartureID = @departureID";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@userID", uTickets.UserID);
                cmd.Parameters.AddWithValue("@ticketID", uTickets.TicketID);
                cmd.Parameters.AddWithValue("@destinationID", uTickets.DestinationID);
                cmd.Parameters.AddWithValue("@departureID", uTickets.DepartureID);

                Thread.Sleep(20);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }
        #endregion



        //SQL helper
        private async Task<List<User>> GetData(SqlDataReader reader)
        {
            List<User> lst = new List<User>();

            try
            {
                while (await reader.ReadAsync())
                {
                    User u = new User()
                    {
                        ID = (Guid)reader["ID"],
                        Email = !Convert.IsDBNull(reader["Email"]) ? (string)reader["Email"] : ""
                    };


                    lst.Add(u);
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
