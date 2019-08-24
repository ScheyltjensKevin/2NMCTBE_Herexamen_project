using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.Models
{
    
    public class Search
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string LeaveDate { get; set; }
        public string ReturnDate { get; set; }
        public bool OneWay { get; set; }
        public string wayString { get; set; }
        [Display(Name ="passengers")]
        public int AmountOfPassengers { get; set; }
    }
}
