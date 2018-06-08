using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ServicoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ServicoEntityTypeConfig : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(s => s.Detalhes)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasOne(v => v.Venda)
                .WithMany(s => s.Servicos)
                .HasForeignKey(s => s.VendaId);
        }
    }
}
