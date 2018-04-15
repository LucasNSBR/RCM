using AutoMapper;
using RCM.Application.ApplicationInterfaces;
using RCM.Application.ViewModels;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace RCM.Application.ApplicationServices
{
    public class ChequeApplicationService : BaseApplicationService<Cheque, ChequeViewModel>, IChequeApplicationService
    {
        public ChequeApplicationService(IChequeRepository chequeRepository, IMapper mapper, IMediatorHandler mediator) : base(chequeRepository, mapper, mediator)
        {
        }

        public override Task<CommandResult> Add(ChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new AddChequeCommand(viewModel.BancoId, viewModel.Agencia, viewModel.Conta, viewModel.NumeroCheque, viewModel.Observacao, viewModel.ClienteId, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor));
        }

        public override Task<CommandResult> Update(ChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new UpdateChequeCommand(viewModel.Id, viewModel.BancoId, viewModel.Agencia, viewModel.Conta, viewModel.NumeroCheque, viewModel.Observacao, viewModel.ClienteId, viewModel.DataEmissao, viewModel.DataVencimento, viewModel.Valor));
        }

        public override Task<CommandResult> Remove(ChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new RemoveChequeCommand(viewModel.Id));
        }

        public Task<CommandResult> BloquearCheque(Guid id)
        {
            return _mediator.SendCommand(new BloquearChequeCommand(id));
        }

        public Task<CommandResult> CompensarCheque(Guid id, EstadoChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new CompensarChequeCommand(id, viewModel.DataEvento));
        }

        public Task<CommandResult> RepassarCheque(Guid id, EstadoChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new RepassarChequeCommand(id, viewModel.DataEvento, viewModel.ClienteId));
        }

        public Task<CommandResult> DevolverCheque(Guid id, EstadoChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new DevolverChequeCommand(id, viewModel.DataEvento, viewModel.Motivo));
        }

        public Task<CommandResult> SustarCheque(Guid id, EstadoChequeViewModel viewModel)
        {
            return _mediator.SendCommand(new SustarChequeCommand(id, viewModel.DataEvento, viewModel.Motivo));
        }
    }
}
