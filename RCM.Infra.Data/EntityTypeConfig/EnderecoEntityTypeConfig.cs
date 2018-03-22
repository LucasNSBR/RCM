using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class EnderecoEntityTypeConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(c => c.Rua)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(c => c.Complemento)
                .HasMaxLength(100);

            builder.Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(8);

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Enderecos)
                .HasForeignKey(c => c.ClienteId);
        }
    }
}
