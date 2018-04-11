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
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.ChequeCommandHandlers
{
    public class ChequeCommandHandler : CommandHandler<Cheque>,
                                        IRequestHandler<AddChequeCommand, CommandResult>,
                                        IRequestHandler<UpdateChequeCommand, CommandResult>,
                                        IRequestHandler<RemoveChequeCommand, CommandResult>
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ChequeCommandHandler(IChequeRepository chequeRepository, IBancoRepository bancoRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                    base(mediator, chequeRepository, unitOfWork)
        {
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

            if (CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                _commandResponse.AddError(new CommandError(RequestErrorsMessageConstants.DuplicataAlreadyExists));
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _baseRepository.Add(cheque);

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

            if (CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                _commandResponse.AddError(new CommandError(RequestErrorsMessageConstants.ChequeAlreadyExists));
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(command.Id, banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _baseRepository.Update(cheque);

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

            Cheque cheque = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(cheque);

            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Response();
        }

        public bool CheckNumeroChequeExists(string numeroDocumento, Guid clienteId, Guid bancoId, Guid novoChequeId)
        {
            var numeroDocumentoSpecification = new ChequeNumeroSpecification(numeroDocumento);
            var clienteIdSpecification = new ChequeClienteIdSpecification(clienteId);
            var bancoIdSpecification = new ChequeBancoIdSpecification(bancoId);

            Cheque cheque = _baseRepository.Get(numeroDocumentoSpecification
                .And(bancoIdSpecification)
                .And(clienteIdSpecification)
                .ToExpression())
                .FirstOrDefault();

            if (cheque == null || novoChequeId == cheque.Id)
                return false;

            return true;
        }
    }
}
