using AutoMapper;
using RCM.Application.ViewModels;
using RCM.Domain.Models;

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
            CreateMap<Cheque, ChequeViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Contato, ContatoViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Banco, BancoViewModel>();
        }
    }
}