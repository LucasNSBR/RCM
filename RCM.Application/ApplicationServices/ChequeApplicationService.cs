using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Repositories;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class ChequeApplicationService : BaseApplicationService<Cheque, ChequeViewModel>, IChequeApplicationService
    {
        public ChequeApplicationService(IChequeRepository chequeRepository, IMapper mapper, IMediatorHandler mediator) : base(chequeRepository, mapper, mediator)
        {
        }

        public override Task<RequestResponse> Add(ChequeViewModel viewModel)
        {
            return _mediator.SendRequest(new AddChequeCommand(viewModel.BancoId, viewModel.Agencia, viewModel.Conta, viewModel.NumeroCheque, viewModel.Observacao, viewModel.ClienteId, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor));
        }

        public override Task<RequestResponse> Update(ChequeViewModel viewModel)
        {
            return _mediator.SendRequest(new UpdateChequeCommand(viewModel.Id, viewModel.BancoId, viewModel.Agencia, viewModel.Conta, viewModel.NumeroCheque, viewModel.Observacao, viewModel.ClienteId, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor));
        }

        public override Task<RequestResponse> Remove(ChequeViewModel viewModel)
        {
            return _mediator.SendRequest(new RemoveChequeCommand(viewModel.Id));
        }
    }
}
