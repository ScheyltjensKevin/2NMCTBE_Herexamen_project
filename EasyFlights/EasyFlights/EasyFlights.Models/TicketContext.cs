using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFlights.Models
{
    public class TicketContext: DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }

        public DbSet<Tickets> Tickets { get; set; }
    }
}
