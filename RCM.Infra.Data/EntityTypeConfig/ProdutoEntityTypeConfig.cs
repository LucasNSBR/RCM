using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ProdutoEntityTypeConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Aplicacao)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(p => p.PrecoVenda)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasOne(p => p.Marca)
                .WithMany(m => m.Produtos)
                .HasForeignKey(p => p.MarcaId);
        }
    }
}
