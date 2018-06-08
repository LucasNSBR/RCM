using Microsoft.EntityFrameworkCore;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.EmpresaModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ServicoModels;
using RCM.Domain.Models.VendaModels;
using RCM.Infra.Data.EntityTypeConfig;
using RCM.Infra.Data.Extensions;

namespace RCM.Infra.Data.Context
{
    public class RCMDbContext : DbContext
    {
        public DbSet<Aplicacao> Aplicacoes { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Duplicata> Duplicatas { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoCheque> EstadosCheques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public RCMDbContext(DbContextOptions<RCMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AplicacaoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new BancoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ChequeEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new DuplicataEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EmpresaEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EstadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new FornecedorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new MarcaEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoAplicacaoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoFornecedorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ServicoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new VendaProdutoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new VendaEntityTypeConfig());

            modelBuilder.ConfigureChequeEstado();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
