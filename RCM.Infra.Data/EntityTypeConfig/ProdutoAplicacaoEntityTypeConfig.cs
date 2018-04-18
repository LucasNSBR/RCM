using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ProdutoAplicacaoEntityTypeConfig : IEntityTypeConfiguration<ProdutoAplicacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoAplicacao> builder)
        {
            builder
                .HasKey(k => new { k.AplicacaoId, k.ProdutoId });

            builder.HasOne(ap => ap.Produto)
                .WithMany(p => p.Aplicacoes)
                .HasForeignKey(ap => ap.ProdutoId);

            builder.HasOne(ap => ap.Aplicacao)
                .WithMany(a => a.Produtos)
                .HasForeignKey(a => a.AplicacaoId);
        }
    }
}
