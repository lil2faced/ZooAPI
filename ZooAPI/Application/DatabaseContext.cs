using Microsoft.EntityFrameworkCore;
using ZooAPI.Application.Entities;

namespace ZooAPI.Application
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Animal> Animals { get; set; }
    }
}
