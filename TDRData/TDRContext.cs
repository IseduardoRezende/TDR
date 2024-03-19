using Microsoft.EntityFrameworkCore;
using TDR.Models;
using TDRData.Models;

namespace TDRData
{
    public class TDRContext : DbContext
    {
        public TDRContext(DbContextOptions<TDRContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Vote> Vote { get; set; }

        public DbSet<Period> Period { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .Property(c => c.InteractionsNumber)
                .HasDefaultValue(3);

            base.OnModelCreating(modelBuilder);
        }
    }
}
