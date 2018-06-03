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
            modelBuilder.Entity<NormalizedEvent>(ev =>
            {
                ev.HasKey(k => k.Id);
                ev.Property(en => en.AggregateId);
                ev.Property(en => en.DateCreated);
                ev.Property(en => en.Type);
                ev.Property(en => en.Data);
            });

            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }
    }
}
