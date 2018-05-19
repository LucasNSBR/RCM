using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ProdutoFornecedorEntityTypeConfig : IEntityTypeConfiguration<ProdutoFornecedor>
    {
        public void Configure(EntityTypeBuilder<ProdutoFornecedor> builder)
        {
            builder.HasKey(k => new { k.ProdutoId, k.FornecedorId });

            builder.HasOne(pf => pf.Produto)
                .WithMany(p => p.Fornecedores)
                .HasForeignKey(pf => pf.ProdutoId);

            builder.HasOne(pf => pf.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(pf => pf.FornecedorId);

            builder.Property(pf => pf.PrecoCusto)
                .IsRequired();

            builder.Property(pf => pf.Disponibilidade)
                .IsRequired();
        }
    }
}
