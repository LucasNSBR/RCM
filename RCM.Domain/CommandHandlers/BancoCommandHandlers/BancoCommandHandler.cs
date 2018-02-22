using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RCM.Domain.Commands.BancoCommands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers.BancoCommandHandlers
{
    public class BancoCommandHandler : CommandHandler<Banco>,
                                       INotificationHandler<AddBancoCommand>,
                                       INotificationHandler<UpdateBancoCommand>,
                                       INotificationHandler<RemoveBancoCommand>
    {
        public BancoCommandHandler(IMediatorHandler mediator, IBaseRepository<Banco> baseRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler) : 
                                                                                                                base(mediator, baseRepository, unitOfWork, domainNotificationHandler)
        {
        }

        public Task Handle(AddBancoCommand notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(UpdateBancoCommand notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemoveBancoCommand notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
