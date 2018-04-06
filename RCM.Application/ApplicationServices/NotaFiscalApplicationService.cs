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
        public NotaFiscalApplicationService(INotaFiscalRepository baseRepository, IMapper mapper, IMediatorHandler mediator) : base(baseRepository, mapper, mediator)
        {
        }

        public override Task<RequestResponse> Add(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendRequest(new AddNotaFiscalCommand(viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override Task<RequestResponse> Update(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateNotaFiscalCommand(viewModel.Id, viewModel.NumeroDocumento, viewModel.DataEmissao, viewModel.Valor));
        }

        public override Task<RequestResponse> Remove(NotaFiscalViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveNotaFiscalCommand(viewModel.Id));
        }
    }
}
