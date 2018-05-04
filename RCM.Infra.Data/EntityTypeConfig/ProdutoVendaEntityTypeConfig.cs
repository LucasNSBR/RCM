using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.VendaModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ProdutoVendaEntityTypeConfig : IEntityTypeConfiguration<ProdutoVenda>
    {
        public void Configure(EntityTypeBuilder<ProdutoVenda> builder)
        {
            builder.HasKey(k => new { k.ProdutoId, k.VendaId });

            builder.Property(pv => pv.Acrescimo)
                .HasMaxLength(4);

            builder.Property(pv => pv.Desconto)
                .HasMaxLength(4);

            builder.Property(pv => pv.PrecoFinal)
                .HasMaxLength(4);
        }
    }
}
