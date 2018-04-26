using AutoMapper;
using RCM.Application.ViewModels;
using RCM.Domain.Models;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.EstadoModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using System.Linq;

namespace RCM.Application.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Duplicata, DuplicataViewModel>();
            CreateMap<NotaFiscal, NotaFiscalViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<EstadoCheque, EstadoChequeViewModel>();
            CreateMap<ChequeBloqueado, EstadoChequeViewModel>();
            CreateMap<ChequeRepassado, EstadoChequeViewModel>();
            CreateMap<ChequeCompensado, EstadoChequeViewModel>();
            CreateMap<ChequeSustado, EstadoChequeViewModel>();
            CreateMap<ChequeDevolvido, EstadoChequeViewModel>();
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Banco, BancoViewModel>();
            CreateMap<Pagamento, PagamentoViewModel>();
            CreateMap<OrdemServico, OrdemServicoViewModel>();
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<ProdutoFornecedor, ProdutoFornecedorViewModel>();

            CreateMap<Aplicacao, AplicacaoViewModel>()
                .ProjectUsing(a => new AplicacaoViewModel
                {
                    Id = a.Id,
                    Ano = a.Carro.Ano,
                    Marca = a.Carro.Marca,
                    Modelo = a.Carro.Modelo,
                    Motor = a.Carro.Motor,
                    Observacao = a.Carro.Observacao
                });

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(a => a.Aplicacoes, cfg =>
                {
                    cfg.MapFrom(p => p.Aplicacoes.Select(a => a.Aplicacao));
                });
        }
    }
}