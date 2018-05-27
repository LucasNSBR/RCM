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

            builder.HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId);

            builder.Property(v => v.Detalhes)
                .HasMaxLength(1000);

            builder.HasMany(v => v.Produtos)
                .WithOne(pv => pv.Venda)
                .HasForeignKey(pv => pv.VendaId);

            builder.Property(v => v.QuantidadeProdutos)
                .IsRequired();

            builder.Property(v => v.TotalVenda)
                .IsRequired();

            builder.Property(v => v.Status)
                .IsRequired();

            builder.Property("_condicaoPagamento")
                .HasColumnName("CondicaoPagamento");

            builder.Ignore(v => v.CondicaoPagamento);
        }
    }
}
