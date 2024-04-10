using KeyNerd.Infrastructure.Security;
using KeyNerd.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeyNerd.Test
{
    public class TestDbContext : AppDbContext
    {
        //public TestDbContext(IUserManager userManager = null) : base(userManager)
        //{
        //}

        public TestDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
