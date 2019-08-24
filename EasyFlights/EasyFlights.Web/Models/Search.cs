using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFlights.Web.Models
{
    
    public class Search
    {
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string LeaveDate { get; set; }
        [Required]
        public string ReturnDate { get; set; }
        [Required]
        public bool OneWay { get; set; }
        public string wayString { get; set; }
        [Display(Name ="passengers")]
        public int AmountOfPassengers { get; set; }
    }
}
