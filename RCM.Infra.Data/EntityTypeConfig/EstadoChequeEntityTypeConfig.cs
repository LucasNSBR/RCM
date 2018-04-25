using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ChequeModels.ChequeStates;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class EstadoChequeEntityTypeConfig : IEntityTypeConfiguration<EstadoCheque>
    {
        public void Configure(EntityTypeBuilder<EstadoCheque> builder)
        {
            builder
                .HasKey(k => k.ChequeId);

            builder.HasOne(c => c.Cheque)
              .WithOne(ec => ec.EstadoCheque)
              .HasForeignKey<EstadoCheque>(c => c.ChequeId);

            builder.Ignore(c => c.Estado);
        }
    }
}
