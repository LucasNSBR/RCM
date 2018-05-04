using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Infra.Data.EntityTypeConfig
{
    public class FornecedorEntityTypeConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder
                .HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Observacao)
                .HasMaxLength(1000);

            builder.OwnsOne(e => e.Documento, cfg =>
            {
                cfg.Property(en => en.CadastroNacional)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("CNPJ");

                cfg.Property(en => en.CadastroEstadual)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("InscricaoEstadual");
            });

            builder.OwnsOne(c => c.Contato, cfg =>
            {
                cfg.Property(co => co.Celular)
                    .HasMaxLength(15)
                    .HasColumnName("ContatoCelular");

                cfg.Property(co => co.Email)
                    .HasMaxLength(100)
                    .HasColumnName("ContatoEmail");

                cfg.Property(co => co.TelefoneComercial)
                    .HasMaxLength(15)
                    .HasColumnName("ContatoTelefoneComercial");

                cfg.Property(co => co.TelefoneResidencial)
                    .HasMaxLength(15)
                    .HasColumnName("ContatoTelefoneResidencial");

                cfg.Property(co => co.Observacao)
                    .HasMaxLength(250)
                    .HasColumnName("ContatoObservacao");
            });

            builder.OwnsOne(e => e.Endereco, cfg =>
            {
                cfg.Property(en => en.Numero)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("EnderecoNumero");

                cfg.Property(en => en.Rua)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EnderecoRua");

                cfg.Property(en => en.Bairro)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("EnderecoBairro");

                cfg.Property(en => en.Complemento)
                    .HasMaxLength(250)
                    .HasColumnName("EnderecoComplemento");

                cfg.Property(en => en.CEP)
                    .HasMaxLength(8)
                    .HasColumnName("EnderecoCEP");
            });
        }
    }
}
