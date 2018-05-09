using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.VendaModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class VendaEntityTypeConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder.Property(v => v.DataVenda)
                .IsRequired();

            builder.Property(v => v.Detalhes)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId);

            builder.HasMany(v => v.Produtos)
                .WithOne(pv => pv.Venda)
                .HasForeignKey(pv => pv.VendaId);

            builder.Property(v => v.Status)
                .IsRequired();

            builder.Property(v => v.QuantidadeProdutos)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(v => v.TotalVenda)
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
