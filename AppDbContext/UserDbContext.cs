using Microsoft.EntityFrameworkCore;
using Session2.Models;

namespace Session2.AppDbContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
