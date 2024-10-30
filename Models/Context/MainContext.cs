using Microsoft.EntityFrameworkCore;

namespace UserInfoApp.Model.Context
{
    public class MainContext : DbContext 
    {
        public DbSet<User> Users { get; set; } = null!;

       // public DbSet<Passport> Passports { get; set; } = null!;

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}