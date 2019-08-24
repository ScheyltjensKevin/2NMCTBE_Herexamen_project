using EasyFlights.API.Models;
using EasyFlights.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFlights.API.Repositories
{
    public interface IBonusPRepository
    {
        Task<BonusPoints> AddPoints(BonusPoints points);
        Task<UserBonusPoints> AddUserBonusPoints(UserBonusPoints userBonus);

        Task<List<BonusPoints>> GetHistoryBonusPoints(User user);
        Task<List<UsersBonusPointsDict>> GetAllHistoryBonusPoints();

        Task DeleteBonusPoints(System.Guid userID);
    }
}