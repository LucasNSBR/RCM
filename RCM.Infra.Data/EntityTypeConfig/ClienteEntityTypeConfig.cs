using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ClienteEntityTypeConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Descricao)
                .HasMaxLength(1000);

            builder.OwnsOne(c => c.Contato, cfg =>
            {
                cfg.Property(co => co.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Celular");

                cfg.Property(co => co.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Email");

                cfg.Property(co => co.TelefoneComercial)
                    .HasMaxLength(15)
                    .HasColumnName("TelefoneComercial");

                cfg.Property(co => co.TelefoneResidencial)
                    .HasMaxLength(15)
                    .HasColumnName("TelefoneResidencial");

                cfg.Property(co => co.Observacao)
                    .HasMaxLength(250)
                    .HasColumnName("ContatoObservacao");
            });
        }
    }
}
