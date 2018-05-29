using AutoMapper;
using RCM.Application.ViewModels;
using RCM.Application.ViewModels.ChequeViewModels;
using RCM.Application.ViewModels.ProdutoViewModels;
using RCM.Application.ViewModels.ValueObjectViewModels;
using RCM.Application.ViewModels.VendaViewModels;
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
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.ValueObjects;
using RCM.Domain.Models.VendaModels;
using System.Linq;

namespace RCM.Application.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<ChequeBloqueado, EstadoChequeViewModel>();
            CreateMap<ChequeCompensado, EstadoChequeViewModel>();
            CreateMap<ChequeDevolvido, EstadoChequeViewModel>();
            CreateMap<ChequeSustado, EstadoChequeViewModel>();
            CreateMap<ChequeRepassado, EstadoChequeViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<EstadoCheque, EstadoChequeViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<OrdemServico, OrdemServicoViewModel>();
            CreateMap<Pagamento, PagamentoViewModel>();
            CreateMap<ProdutoFornecedor, ProdutoFornecedorViewModel>();
            CreateMap<VendaProduto, VendaProdutoViewModel>();

            CreateMap<Aplicacao, AplicacaoViewModel>()
               .ProjectUsing(a => new AplicacaoViewModel
               {
                   Id = a.Id,
                   CarroAno = a.Carro.Ano,
                   CarroMarca = a.Carro.Marca,
                   CarroModelo = a.Carro.Modelo,
                   CarroMotor = a.Carro.Motor,
                   Observacao = a.Carro.Observacao
               });

            CreateMap<Duplicata, DuplicataViewModel>()
                .ForMember(p => p.Pagamento, cfg =>
                {
                    cfg.MapFrom(d => (d.Pagamento.DataPagamento == null || d.Pagamento.ValorPago == null) ? null : d.Pagamento);
                });

            CreateMap<CondicaoPagamento, CondicaoPagamentoViewModel>()
                .ForMember(p => p.Parcelas, cfg =>
                {
                    cfg.MapFrom(p => p.Parcelas ?? null);
                });

            CreateMap<Parcela, ParcelaViewModel>()
                .ForMember(p => p.Venda, cfg => cfg.Ignore())
                .ForMember(p => p.VendaId, cfg => cfg.Ignore());

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(a => a.Aplicacoes, cfg =>
                {
                    cfg.MapFrom(p => p.Aplicacoes.Select(a => a.Aplicacao));
                })
                .ForMember(pf => pf.ProdutoFornecedores, cfg =>
                {
                    cfg.MapFrom(p => p.Fornecedores);
                });

            CreateMap<Venda, VendaViewModel>()
                .ForMember(p => p.CondicaoPagamento, cfg =>
                {
                    cfg.MapFrom(v => v.CondicaoPagamento ?? null);
                });
        }
    }
}