﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.DuplicataModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class DuplicataEntityTypeConfig : IEntityTypeConfiguration<Duplicata>
    {
        public void Configure(EntityTypeBuilder<Duplicata> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder.Property(d => d.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Observacao)
                .HasMaxLength(1000);

            builder.Property(d => d.DataEmissao)
                .IsRequired();

            builder.Property(d => d.DataVencimento)
                .IsRequired();

            builder.Property(d => d.NotaFiscalId)
                .HasMaxLength(6);

            builder.Property(d => d.Valor)
                .IsRequired();

            builder.HasOne(d => d.Fornecedor)
                .WithMany(f => f.Duplicatas)
                .HasForeignKey(d => d.FornecedorId)
                .IsRequired();

            builder.OwnsOne(d => d.Pagamento, cfg => {
                cfg.Property(d => d.DataPagamento).HasColumnName("DataPagamento");
                cfg.Property(d => d.ValorPago).HasColumnName("ValorPago");
            });
        }
    }
}
