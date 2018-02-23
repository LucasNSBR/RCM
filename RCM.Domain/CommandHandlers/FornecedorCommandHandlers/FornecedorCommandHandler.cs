using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Events.FornecedorEvents;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

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

        public Task Handle(AddFornecedorCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Fornecedor);
      
            if (Commit())
                _mediator.Publish(new AddedFornecedorEvent());

            return Task.CompletedTask;
        }

        public Task Handle(UpdateFornecedorCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Fornecedor);

            if (Commit())
                _mediator.Publish(new UpdatedFornecedorEvent());

            return Task.CompletedTask;
        }

        public Task Handle(RemoveFornecedorCommand notification, CancellationToken cancellationToken)
        {
            if (!Valid(notification))
                return Task.CompletedTask;

            _baseRepository.Add(notification.Fornecedor);

            if (Commit())
                _mediator.Publish(new RemovedFornecedorEvent());

            return Task.CompletedTask;
        }
    }
}
