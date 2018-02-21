using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class DuplicataApplicationService : BaseApplicationService<Duplicata, DuplicataViewModel>, IDuplicataApplicationService
    {
        public DuplicataApplicationService(IDuplicataRepository duplicataRepository, IMapper mapper, IMediatorHandler mediator) : base(duplicataRepository, mapper, mediator)
        {
        }
    }
}
