using MediatR;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Constants;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ChequeCommandHandlers
{
    public class ChequeCommandHandler : CommandHandler<Cheque>,
                                        IRequestHandler<AddChequeCommand, CommandResult>,
                                        IRequestHandler<UpdateChequeCommand, CommandResult>,
                                        IRequestHandler<RemoveChequeCommand, CommandResult>,
                                        IRequestHandler<BloquearChequeCommand, CommandResult>,
                                        IRequestHandler<RepassarChequeCommand, CommandResult>,
                                        IRequestHandler<CompensarChequeCommand, CommandResult>,
                                        IRequestHandler<DevolverChequeCommand, CommandResult>,
                                        IRequestHandler<SustarChequeCommand, CommandResult>
    {
        private readonly IChequeRepository _chequeRepository;
        private readonly IBancoRepository _bancoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ChequeCommandHandler(IChequeRepository chequeRepository, IBancoRepository bancoRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                    base(mediator, unitOfWork)
        {
            _chequeRepository = chequeRepository;
            _bancoRepository = bancoRepository;
            _clienteRepository = clienteRepository;
        }

        public Task<CommandResult> Handle(AddChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            if (_chequeRepository.CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                _commandResponse.AddError(new CommandError(RequestErrorsMessageConstants.ChequeAlreadyExists));
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _chequeRepository.Add(cheque);

            if (Commit())
                _mediator.Publish(new AddedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(UpdateChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            if (_chequeRepository.CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                _commandResponse.AddError(new CommandError(RequestErrorsMessageConstants.ChequeAlreadyExists));
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(command.Id, banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RemoveChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyRequestErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);
            _chequeRepository.Remove(cheque);

            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(BloquearChequeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> Handle(RepassarChequeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> Handle(CompensarChequeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> Handle(DevolverChequeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> Handle(SustarChequeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
