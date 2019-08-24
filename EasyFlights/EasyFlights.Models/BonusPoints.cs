using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Models
{
    public class BonusPoints
    {
        public Guid Id { get; set; }
        public int  Points { get; set; }
        public DateTime DateAquired { get; set; }
    }
}
