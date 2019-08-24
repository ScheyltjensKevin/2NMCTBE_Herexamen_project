using Microsoft.EntityFrameworkCore;

namespace EasyFlights.Models
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public void MarkAsModified(User item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
