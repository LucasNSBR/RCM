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

            builder.Property(e => e.Sigla)
                .HasMaxLength(2);

            builder.Property(e => e.Nome)
                .HasMaxLength(25);
        }
    }
}
