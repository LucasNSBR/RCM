using AutoMapper;
using RCM.Application.ViewModels;
using RCM.Application.ViewModels.ChequeViewModels;
using RCM.Application.ViewModels.ProdutoViewModels;
using RCM.Application.ViewModels.VendaViewModels;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.DuplicataModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Models.MarcaModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Models.VendaModels;

namespace RCM.Application.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BancoViewModel, Banco>();
            CreateMap<ChequeViewModel, Cheque>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<DuplicataViewModel, Duplicata>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<MarcaViewModel, Marca>();
            CreateMap<OrdemServicoViewModel, OrdemServico>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<VendaViewModel, Venda>();
        }
    }
}