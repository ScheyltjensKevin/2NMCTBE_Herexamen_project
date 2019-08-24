using EasyFlights.API.Models;
using EasyFlights.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Repositories
{
    public class BonusPRepository : IBonusPRepository
    {

        private readonly string connectionString;
        private readonly IUserRepository _userRepository;
        public BonusPRepository(IConfiguration config, IUserRepository userRepository)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");

            _userRepository = userRepository;
        }

        public async Task<BonusPoints> AddPoints(BonusPoints points)
        {
            BonusPoints pts = new BonusPoints();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "Insert into BonusPoints(Id, Points, DateAquired)";
                sql += " Values(@Id, @Points,@DateAquired)";

                SqlCommand cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@Id", points.Id);
                cmd.Parameters.AddWithValue("@Points", points.Points);
                cmd.Parameters.AddWithValue("@DateAquired", points.DateAquired);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                return pts;

            }
        }

        public async Task<UserBonusPoints> AddUserBonusPoints(UserBonusPoints userBonus)
        {
            UserBonusPoints usrBonus = new UserBonusPoints();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO UserBonusPoints(Id, UserID, PointID)";
                sql += "Values(@Id, @UserId, @PointId)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Id", userBonus.Id);
                cmd.Parameters.AddWithValue("@UserId", userBonus.UserID);
                cmd.Parameters.AddWithValue("@PointId", userBonus.PointID);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                return usrBonus;
            }
        }

        private async Task<List<UserBonusPoints>> GetAllUserBonusPoints()
        {
            List<UserBonusPoints> lst = new List<UserBonusPoints>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM UserBonusPoints";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetDataUBP(reader);
                con.Close();
            }
            return lst;
        }
        private async Task<List<User>> GetAllUsers()
        {
            List<User> lst = new List<User>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetDataUser(reader);
                con.Close();
            }
            return lst;
        }

        private async Task<List<BonusPoints>> GetAllBonusPoints()
        {
            List<BonusPoints> lst = new List<BonusPoints>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM BonusPoints";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lst = await GetAllData(reader);
                con.Close();
            }
            return lst;
        }


        public async Task<List<UsersBonusPointsDict>> GetAllHistoryBonusPoints()
        {
            List<UserBonusPoints> lstUBP = new List<UserBonusPoints>();
            List<User> lstUser = new List<User>();
            List<BonusPoints> lst = new List<BonusPoints>();

            List<UsersBonusPointsDict> dict = new List<UsersBonusPointsDict>();

            lstUBP = await GetAllUserBonusPoints();
            lstUser = await GetAllUsers();
            lst = await GetAllBonusPoints();

            foreach (var item in lstUBP)
            {
                for (int i = 0; i < lstUser.Count; i++)
                {
                    if (lstUser[i].ID == item.UserID)
                    {
                        for (int x = 0; x < lst.Count; x++)
                        {
                            if (lst[x].Id == item.PointID)
                            {
                                //dict.Add(lstUser[i], lst[x]);
                                UsersBonusPointsDict ubpDict = new UsersBonusPointsDict()
                                {
                                    User = lstUser[i],
                                    BonusPoints = lst[x]
                                };

                                dict.Add(ubpDict);
                            }
                        }
                    }
                }
            }

            return dict;
        }

        public async Task<List<BonusPoints>> GetHistoryBonusPoints(User user)
        {
            List<BonusPoints> lst = new List<BonusPoints>();
            List<UserBonusPoints> lstUBP = new List<UserBonusPoints>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM UserBonusPoints Where UserID = @UID";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text,
                };
                cmd.Parameters.AddWithValue("@UID", user.ID);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstUBP = await GetDataUBP(reader);
                con.Close();

                foreach (var item in lstUBP)
                {
                    lst = await GetBonusPoints(lstUBP);
                }
            }
            return lst;
        }

        private async Task<List<BonusPoints>> GetBonusPoints(List<UserBonusPoints> lstUBP)
        {
            List<BonusPoints> lst = new List<BonusPoints>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                foreach (var item in lstUBP)
                {
                    string sql = "SELECT * FROM BonusPoints Where Id = @ID";
                    SqlCommand cmd = new SqlCommand(sql, con)
                    {
                        CommandType = System.Data.CommandType.Text,
                    };
                    cmd.Parameters.AddWithValue("@ID", item.PointID);

                    con.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    lst.Add(await GetData(reader));
                    con.Close();

                }
            }
            return lst;
        }


        public async Task DeleteBonusPoints(Guid userID)
        {
            List<UserBonusPoints> lstUBP = new List<UserBonusPoints>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM UserBonusPoints Where UserID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.Text
                };
                cmd.Parameters.AddWithValue("@ID", userID);

                con.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                lstUBP = await GetDataUBP(reader);
                con.Close();

                string sql1 = "DELETE FROM UserBonusPoints Where UserID = @ID";
                SqlCommand cmd1 = new SqlCommand(sql1, con)
                {
                    CommandType = System.Data.CommandType.Text
                };
                cmd1.Parameters.AddWithValue("@ID", userID);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();

                for (int i = 0; i < lstUBP.Count; i++)
                {
                    string sql2 = "DELETE FROM BonusPoints Where Id = @ID";
                    SqlCommand cmd2 = new SqlCommand(sql2, con)
                    {
                        CommandType = System.Data.CommandType.Text
                    };
                    cmd2.Parameters.AddWithValue("@ID", lstUBP[i].Id);

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                }


            }
        }

        private async Task<BonusPoints> GetData(SqlDataReader reader)
        {
            BonusPoints p = new BonusPoints();
            try
            {
                while (await reader.ReadAsync())
                {
                    BonusPoints points = new BonusPoints()
                    {
                        Id = (Guid)reader["Id"],
                        Points = (int)reader["Points"],
                        DateAquired = Convert.ToDateTime(reader["DateAquired"])
                    };
                    p = points;
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
            return p;
        }
        private async Task<List<User>> GetDataUser(SqlDataReader reader)
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
        private async Task<List<BonusPoints>> GetAllData(SqlDataReader reader)
        {
            List<BonusPoints> lst = new List<BonusPoints>();
            try
            {
                while (await reader.ReadAsync())
                {
                    BonusPoints points = new BonusPoints()
                    {
                        Id = (Guid)reader["Id"],
                        Points = (int)reader["Points"],
                        DateAquired = Convert.ToDateTime(reader["DateAquired"])
                    };
                    lst.Add(points);
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

        private async Task<List<UserBonusPoints>> GetDataUBP(SqlDataReader reader)
        {
            List<UserBonusPoints> lst = new List<UserBonusPoints>();

            try
            {
                while (await reader.ReadAsync())
                {
                    UserBonusPoints points = new UserBonusPoints()
                    {
                        Id = (Guid)reader["Id"],
                        UserID = (Guid)reader["UserID"],
                        PointID = (Guid)reader["PointID"]
                    };


                    lst.Add(points);
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
