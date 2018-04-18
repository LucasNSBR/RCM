using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class AplicacaoEntityTypeConfig : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.OwnsOne(c => c.Carro, cfg =>
            {
                cfg.Property(c => c.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Marca");

                cfg.Property(c => c.Modelo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Modelo");

                cfg.Property(c => c.Ano)
                    .HasColumnName("Ano");

                cfg.Property(c => c.Observacao)
                    .HasColumnName("Observacao");

                cfg.Property(c => c.Motor)
                    .HasColumnName("Motor");
            });
        }
    }
}

