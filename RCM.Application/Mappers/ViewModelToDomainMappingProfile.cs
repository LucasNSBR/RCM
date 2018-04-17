using AutoMapper;
using RCM.Application.ViewModels;
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

namespace RCM.Application.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<DuplicataViewModel, Duplicata>();
            CreateMap<NotaFiscalViewModel, NotaFiscal>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<ChequeViewModel, Cheque>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<BancoViewModel, Banco>();
            CreateMap<OrdemServicoViewModel, OrdemServico>();
            CreateMap<MarcaViewModel, Marca>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}