using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.ViewModels
{
    public class UserVM
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public int TotalPoints { get; set; }
    }
}
