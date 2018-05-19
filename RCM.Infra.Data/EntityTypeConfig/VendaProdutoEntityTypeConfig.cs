using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.VendaModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class VendaProdutoEntityTypeConfig : IEntityTypeConfiguration<VendaProduto>
    {
        public void Configure(EntityTypeBuilder<VendaProduto> builder)
        {
            builder.HasKey(k => new { k.ProdutoId, k.VendaId });

            builder.Property(pv => pv.PrecoVenda)
                .IsRequired();

            builder.Property(pv => pv.PrecoFinal)
                .IsRequired();

            builder.Property(pv => pv.Quantidade)
                .IsRequired();
       }
    }
}
