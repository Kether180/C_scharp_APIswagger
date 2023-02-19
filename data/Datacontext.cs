using Microsoft.EntityFrameworkCore;
using Minitwit7.Models;

namespace Minitwit7.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Follower> Followers => Set<Follower>();
        public DbSet<Message> Messages => Set<Message>();

    }
}

