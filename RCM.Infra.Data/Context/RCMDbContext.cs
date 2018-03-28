﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RCM.Domain.Models;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;
using RCM.Infra.Data.EntityTypeConfig;
using System.IO;

namespace RCM.Infra.Data.Context
{
    public class RCMDbContext : DbContext
    {
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Duplicata> Duplicatas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public RCMDbContext(DbContextOptions<RCMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BancoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ChequeEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ContatoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new DuplicataEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EnderecoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EstadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new FornecedorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new NotaFiscalEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new OrdemServicoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new VendaEntityTypeConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(config.GetConnectionString("RCMDatabase"));
        }
    }
}
