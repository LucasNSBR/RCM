using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Repositories;

namespace RCM.Application.ApplicationServices
{
    public class NotaFiscalApplicationService : BaseApplicationService<NotaFiscal, NotaFiscalViewModel>, INotaFiscalApplicationService
    {
        public NotaFiscalApplicationService(INotaFiscalRepository baseRepository, IMapper mapper, IMediatorHandler mediator) : base(baseRepository, mapper, mediator)
        {
        }

        public override void Add(NotaFiscalViewModel viewModel)
        {
            _mediator.SendCommand(new AddNotaFiscalCommand(viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override void Update(NotaFiscalViewModel viewModel)
        {
            _mediator.SendCommand(new UpdateNotaFiscalCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override void Remove(NotaFiscalViewModel viewModel)
        {
            _mediator.SendCommand(new RemoveNotaFiscalCommand(viewModel.Id));
        }
    }
}
