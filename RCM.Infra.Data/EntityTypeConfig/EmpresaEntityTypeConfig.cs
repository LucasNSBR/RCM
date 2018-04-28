using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.EmpresaModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class EmpresaEntityTypeConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(e => e.NomeFantasia)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.RazaoSocial)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(e => e.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
