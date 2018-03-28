using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.NotaFiscalModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class NotaFiscalEntityTypeConfig : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder.Property(n => n.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(n => n.DataEmissao)
                .IsRequired();

            builder.Property(n => n.DataChegada)
                .IsRequired();

            builder.Property(n => n.Valor)
                .IsRequired()
                .HasMaxLength(4);
        }
    }
}
