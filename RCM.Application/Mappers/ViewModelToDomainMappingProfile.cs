using AutoMapper;
using RCM.Application.ViewModels;
using RCM.Domain.Models;

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
        }
    }
}