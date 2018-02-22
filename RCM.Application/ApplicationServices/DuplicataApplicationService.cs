using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.DuplicataCommands;
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

        public override void Add(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new AddDuplicataCommand(ProjectToModel(viewModel)));
        }

        public override void Update(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateDuplicataCommand(ProjectToModel(viewModel)));
        }

        public override void Remove(DuplicataViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveDuplicataCommand(ProjectToModel(viewModel)));
        }
    }
}
