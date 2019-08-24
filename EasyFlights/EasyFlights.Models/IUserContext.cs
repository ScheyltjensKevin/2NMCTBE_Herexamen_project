using Microsoft.EntityFrameworkCore;
using System;

namespace EasyFlights.Models
{
    public interface IUserContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
        void MarkAsModified(User item);
    }
}