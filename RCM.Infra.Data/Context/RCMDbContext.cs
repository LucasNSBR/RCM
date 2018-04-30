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
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;
using RCM.Infra.Data.EntityTypeConfig;

namespace RCM.Infra.Data.Context
{
    public class RCMDbContext : DbContext
    {
        public DbSet<Aplicacao> Aplicacoes { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Duplicata> Duplicatas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EstadoCheque> EstadosCheques { get; set; }

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
            modelBuilder.ApplyConfiguration(new EstadoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new FornecedorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new MarcaEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new NotaFiscalEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new OrdemServicoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoAplicacaoEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ProdutoFornecedorEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new VendaEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new EmpresaEntityTypeConfig());

            ConfigureChequeEstado(modelBuilder);
        }

        private void ConfigureChequeEstado(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoChequeEntityTypeConfig());

            modelBuilder.Entity<ChequeBloqueado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeCompensado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeRepassado>().HasBaseType<EstadoCheque>();
            modelBuilder.Entity<ChequeSustado>().HasBaseType<EstadoCheque>();

            modelBuilder.Entity<ChequeSustado>().Property(m => m.Motivo).HasMaxLength(100).HasColumnName("Motivo");
            modelBuilder.Entity<ChequeDevolvido>().Property(m => m.Motivo).HasMaxLength(100).HasColumnName("Motivo");

            modelBuilder.Entity<ChequeDevolvido>().HasBaseType<EstadoCheque>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
