using MediatR;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Constants;
using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Events.ChequeEvents;
using RCM.Domain.Models.BancoModels;
using RCM.Domain.Models.ChequeModels;
using RCM.Domain.Models.ChequeModels.ChequeStates;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System;
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
        private readonly IFornecedorRepository _fornecedorRepository;

        public ChequeCommandHandler(IChequeRepository chequeRepository, IBancoRepository bancoRepository, IClienteRepository clienteRepository, IFornecedorRepository fornecedorRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork) : 
                                                                                                    base(mediator, unitOfWork)
        {
            _chequeRepository = chequeRepository;
            _bancoRepository = bancoRepository;
            _clienteRepository = clienteRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<CommandResult> Handle(AddChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            if (_chequeRepository.CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                NotifyCommandError(RequestErrorsMessageConstants.ChequeAlreadyExists);
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId, loadRelatedData: false);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId, loadRelatedData: false);
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
                NotifyCommandErrors(command);
                return Response();
            }

            if (_chequeRepository.CheckNumeroChequeExists(command.NumeroCheque, command.ClienteId, command.BancoId, command.Id))
            {
                NotifyCommandError(RequestErrorsMessageConstants.ChequeAlreadyExists);
                return Response();
            }

            Banco banco = _bancoRepository.GetById(command.BancoId, loadRelatedData: false);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId, loadRelatedData: false);
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
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);
            _chequeRepository.Remove(cheque);

            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(BloquearChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);
            cheque.Bloquear(command.DataEvento);
            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(RepassarChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);
            Fornecedor fornecedor = _fornecedorRepository.GetById(command.FornecedorRepassadoId);

            if (!NotifyNullCheckState(cheque))
                cheque.Repassar(command.DataEvento, fornecedor);

            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(CompensarChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);
            if (!NotifyNullCheckState(cheque))
                cheque.Compensar(command.DataEvento);

            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(DevolverChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);

            if (!NotifyNullCheckState(cheque))
                cheque.Devolver(command.DataEvento, command.Motivo);

            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        public Task<CommandResult> Handle(SustarChequeCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyCommandErrors(command);
                return Response();
            }

            Cheque cheque = _chequeRepository.GetById(command.Id);

            if (!NotifyNullCheckState(cheque))
                cheque.Sustar(command.DataEvento, command.Motivo);

            _chequeRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Response();
        }

        private bool NotifyNullCheckState(Cheque cheque)
        {
            if (cheque.EstadoCheque != null)
                return false;
            else
            {
                NotifyCommandError(RequestErrorsMessageConstants.ChequeStateNull);
                cheque.Bloquear(DateTime.Now);
            }

            return true;
        }
    }
}
