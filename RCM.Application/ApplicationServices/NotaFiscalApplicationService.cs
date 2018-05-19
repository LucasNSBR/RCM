using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.NotaFiscalCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class NotaFiscalApplicationService : BaseApplicationService<NotaFiscal, NotaFiscalViewModel>, INotaFiscalApplicationService
    {
        public NotaFiscalApplicationService(INotaFiscalRepository notaFiscalRepository, IMapper mapper, IMediatorHandler mediator) : base(notaFiscalRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendCommand(new AddNotaFiscalCommand(viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override Task<CommandResult> Update(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateNotaFiscalCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override Task<CommandResult> Remove(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveNotaFiscalCommand(viewModel.Id));
        }
    }
}
