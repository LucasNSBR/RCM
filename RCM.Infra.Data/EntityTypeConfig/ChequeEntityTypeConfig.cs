using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.ChequeModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class ChequeEntityTypeConfig : IEntityTypeConfiguration<Cheque>
    {
        public void Configure(EntityTypeBuilder<Cheque> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.HasOne(c => c.Banco)
                .WithMany(b => b.Cheques)
                .HasForeignKey(c => c.BancoId)
                .IsRequired();

            builder.Property(c => c.Agencia)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(c => c.Conta)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(c => c.NumeroCheque)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(c => c.Observacao)
                .HasMaxLength(1000);

            builder.HasOne(c => c.Cliente)
                .WithMany(cl => cl.Cheques)
                .HasForeignKey(c => c.ClienteId)
                .IsRequired();

            builder.Property(c => c.DataEmissao)
                .IsRequired();

            builder.Property(c => c.DataVencimento)
                .IsRequired();

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasMaxLength(4);
        }
    }
}
