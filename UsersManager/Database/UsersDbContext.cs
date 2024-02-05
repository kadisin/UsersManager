using Microsoft.EntityFrameworkCore;
using UsersManager.Models;

namespace UsersManager.Database
{
    public class UsersDbContext : DbContext
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bike> Bikes { get; set; }
    }
}
