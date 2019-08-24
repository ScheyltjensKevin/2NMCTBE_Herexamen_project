using System;
using System.Collections.Generic;

namespace EasyFlights.Models
{
    public class User  
    {
        public Guid ID { get; set; }
        public string Email { get; set; }

        public int Administrator { get; set; }
    }
}
