using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.API.Models
{
    public class UserBonusPoints
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Guid PointID { get; set; }

    }
}
