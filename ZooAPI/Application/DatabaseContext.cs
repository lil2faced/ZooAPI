using Microsoft.EntityFrameworkCore;
using ZooAPI.Application.Entities;

namespace ZooAPI.Application
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Animal> Animals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }
    }
}
