using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class ChequeApplicationService : BaseApplicationService<Cheque, ChequeViewModel>, IChequeApplicationService
    {
        public ChequeApplicationService(IChequeRepository chequeRepository, IMapper mapper, IMediatorHandler mediator) : base(chequeRepository, mapper, mediator)
        {
        }

        public override void Add(ChequeViewModel viewModel)
        {
            var model = _mapper.Map<Cheque>(viewModel);
            _mediator.SendCommand(new AddChequeCommand(model));
        }
    }
}
