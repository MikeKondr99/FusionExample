using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Users
{

    public enum Sex
    {
        Male,
        Female
    }

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Sex Sex { get; set; }
    }

    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        } 

        public DbSet<User> Users => Set<User>();
    }
}
