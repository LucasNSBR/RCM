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
                cfg.Property(c => c.Ano)
                    .HasMaxLength(4)
                    .HasColumnName("CarroAno");

                cfg.Property(c => c.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CarroMarca");

                cfg.Property(c => c.Modelo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CarroModelo");

                cfg.Property(c => c.Motor)
                    .HasMaxLength(100)
                    .HasColumnName("CarroMotor");

                cfg.Property(c => c.Observacao)
                    .HasMaxLength(1000)
                    .HasColumnName("Observacao");
            });
        }
    }
}

