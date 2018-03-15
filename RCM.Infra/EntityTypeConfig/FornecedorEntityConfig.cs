using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models;

namespace RCM.Infra.EntityTypeConfig
{
    public class FornecedorEntityConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasMany(f => f.Duplicatas).WithOne(d => d.Fornecedor).HasForeignKey(d => d.FornecedorId);
            //builder.HasMany(f => f.NotasFiscais).WithOne(n => n.Fornecedor).HasForeignKey(n => n.FornecedorId);
        }
    }
}
