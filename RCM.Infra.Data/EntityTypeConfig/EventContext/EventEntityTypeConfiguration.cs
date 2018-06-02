using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Core.Events;

namespace RCM.Infra.Data.EntityTypeConfig.EventContext
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<NormalizedEvent>
    {
        public void Configure(EntityTypeBuilder<NormalizedEvent> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.AggregateId)
                .IsRequired();

            builder.Property(e => e.DateCreated)
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired();

            builder.Property(e => e.Data)
                .IsRequired();
        }
    }
}
