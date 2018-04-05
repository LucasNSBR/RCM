using MediatR;
using RCM.Domain.Commands.ChequeCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
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
                                        INotificationHandler<AddChequeCommand>,
                                        INotificationHandler<UpdateChequeCommand>,
                                        INotificationHandler<RemoveChequeCommand>
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ChequeCommandHandler(IChequeRepository chequeRepository, IBancoRepository bancoRepository, IClienteRepository clienteRepository, IMediatorHandler mediator, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                    base(mediator, chequeRepository, unitOfWork, domainNotificationHandler)
        {
            _bancoRepository = bancoRepository;
            _clienteRepository = clienteRepository;
        }

        public Task Handle(AddChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _baseRepository.Add(cheque);

            if (Commit())
                _mediator.Publish(new AddedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Banco banco = _bancoRepository.GetById(command.BancoId);
            Cliente cliente = _clienteRepository.GetById(command.ClienteId);
            Cheque cheque = new Cheque(command.Id, banco, command.Agencia, command.Conta, command.NumeroCheque, cliente, command.DataEmissao, command.DataVencimento, command.Valor);
            _baseRepository.Update(cheque);

            if (Commit())
                _mediator.Publish(new UpdatedChequeEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveChequeCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Cheque cheque = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(cheque);

            if (Commit())
                _mediator.Publish(new RemovedChequeEvent());

            return Task.CompletedTask;
        }
    }
}
