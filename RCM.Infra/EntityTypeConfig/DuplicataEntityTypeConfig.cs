using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models;

namespace RCM.Infra.EntityTypeConfig
{
    public class DuplicataEntityTypeConfig : IEntityTypeConfiguration<Duplicata>
    {
        public void Configure(EntityTypeBuilder<Duplicata> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Fornecedor).WithMany(f => f.Duplicatas).HasForeignKey(d => d.FornecedorId);
            builder.HasOne(d => d.NotaFiscal).WithMany(n => n.Duplicatas).HasForeignKey(d => d.NotaFiscalId);
        }
    }
}
