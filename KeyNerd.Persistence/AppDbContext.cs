using KeyNerd.Domain.Entities;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace KeyNerd.Persistence
{
    public  class AppDbContext : DbContext
    {
        #region Members

        private readonly IUserManager userManager;

        #endregion

        #region Properties

        public DbSet<Category> Categories { get; set; }

        public DbSet<Keycap> Keycaps { get; set; }

        public DbSet<KeycapDetail> KeycapDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<KeycapPhoto> KeycapPhotos { get; set; }

        #endregion

        #region Constructors

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
            //this.userManager = userManager;
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuditData();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            AddAuditData();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditData()
        {
            var addedEntries = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AuditableEntity && x.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                ((AuditableEntity)entry.Entity).CreatedBy = "Admin";
            }

            var utcNow = DateTime.UtcNow;
            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AuditableEntity && x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                ((AuditableEntity)entry.Entity).ModifiedAt = utcNow;
                ((AuditableEntity)entry.Entity).ModifiedBy = "Admin";
            }
        }

        #endregion

        #region Events


        #endregion
    }
}
