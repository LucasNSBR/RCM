using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.EstadoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class EstadoEntityTypeConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}
