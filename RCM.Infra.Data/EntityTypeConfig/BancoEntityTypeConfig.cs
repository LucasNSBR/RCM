﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.BancoModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class BancoEntityTypeConfig : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder.Property(b => b.CodigoCompensacao)
                .IsRequired();

            builder.Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
