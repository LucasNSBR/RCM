using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class MarcaApplicationService : BaseApplicationService<Marca, MarcaViewModel>, IMarcaApplicationService
    {
        public MarcaApplicationService(IMarcaRepository marcaRepository, IMapper mapper, IMediatorHandler mediator) : base(marcaRepository, mapper, mediator)
        {
        }
    }
}
