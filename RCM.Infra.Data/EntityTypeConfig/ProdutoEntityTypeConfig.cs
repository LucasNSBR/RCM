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

            builder.Property(p => p.Unidade)
                .IsRequired();

            builder.Property(p => p.ReferenciaFabricante)
                .HasMaxLength(25);

            builder.Property(p => p.ReferenciaOriginal)
                .HasMaxLength(25);

            builder.Property(p => p.ReferenciaAuxiliar)
                .HasMaxLength(50);

            builder.Property(p => p.ReferenciaUrl)
                .HasMaxLength(150);

            builder.Property(p => p.Estoque)
                .IsRequired();

            builder.Property(p => p.EstoqueMinimo)
                .IsRequired();

            builder.Property(p => p.EstoqueIdeal)
                .IsRequired();

            builder.Property(p => p.EstoqueIdeal)
                .IsRequired();

            builder.Property(p => p.EstoqueLocalizacao)
                .HasMaxLength(4);

            builder.Property(p => p.PrecoVenda)
                .IsRequired();

            builder.HasOne(p => p.Marca)
                .WithMany(m => m.Produtos)
                .HasForeignKey(p => p.MarcaId);

            builder.HasIndex(p => p.ReferenciaFabricante);
            builder.HasIndex(p => p.ReferenciaOriginal);
            builder.HasIndex(p => p.ReferenciaAuxiliar);
        }
    }
}
