using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ContatoEntityTypeConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Observacao)
                .HasMaxLength(1000);

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Contatos)
                .HasForeignKey(c => c.ClienteId);
        }
    }
}
