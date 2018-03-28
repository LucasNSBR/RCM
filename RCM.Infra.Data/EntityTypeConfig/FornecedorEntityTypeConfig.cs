using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class FornecedorEntityTypeConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder
                .HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Observacao)
                .HasMaxLength(1000);
        }
    }
}
