using MediatR;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.FornecedorEvents;
using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers.FornecedorCommandHandlers
{
    public class FornecedorCommandHandler : CommandHandler<Fornecedor>,
                                            INotificationHandler<AddFornecedorCommand>,
                                            INotificationHandler<UpdateFornecedorCommand>,
                                            INotificationHandler<RemoveFornecedorCommand>
    {
        public FornecedorCommandHandler(IMediatorHandler mediator, IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) :
                                                                                                                base(mediator, fornecedorRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Fornecedor fornecedor = new Fornecedor(command.Nome, command.Observacao);
            _baseRepository.Add(fornecedor);
      
            if (Commit())
                _mediator.Publish(new AddedFornecedorEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Fornecedor fornecedor = new Fornecedor(command.Id, command.Nome, command.Observacao);
            _baseRepository.Update(fornecedor);

            if (Commit())
                _mediator.Publish(new UpdatedFornecedorEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveFornecedorCommand command, CancellationToken cancellationToken)
        {
            if (NotifyCommandErrors(command))
                return Task.CompletedTask;

            Fornecedor fornecedor = _baseRepository.GetById(command.Id);
            _baseRepository.Remove(fornecedor);

            if (Commit())
                _mediator.Publish(new RemovedFornecedorEvent());

            return Task.CompletedTask;
        }
    }
}
