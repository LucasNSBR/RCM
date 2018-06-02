using Microsoft.EntityFrameworkCore;
using RCM.Domain.Core.Events;
using RCM.Infra.Data.EntityTypeConfig.EventContext;

namespace RCM.Infra.Data.Context
{
    public class RCMEventDbContext : DbContext
    {
        public RCMEventDbContext(DbContextOptions<RCMEventDbContext> options) : base(options)
        {
        }

        public DbSet<NormalizedEvent> DomainEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }
    }
}
