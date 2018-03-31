using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;

namespace RCM.Domain.CommandHandlers
{
    public abstract class CommandHandler<TModel> where TModel : class
    {
        protected readonly IMediatorHandler _mediator;
        protected readonly IBaseRepository<TModel> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IDomainNotificationHandler _domainNotificationHandler;

        public CommandHandler(IMediatorHandler mediator, IBaseRepository<TModel> baseRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler)
        {
            _mediator = mediator;
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected bool Commit()
        {
            var commandResult = _unitOfWork.Commit();
            
            if (commandResult.Success)
                return true;
            else
            {
                foreach (var error in commandResult.Errors)
                {
                    _domainNotificationHandler.AddNotification(new CommitErrorNotification(error.InnerException.Message));
                }
            }

            return false;
        }

        protected bool NotifyCommandErrors(Command command)
        {
            if (!_domainNotificationHandler.IsEmpty())
                return true;
            
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    _domainNotificationHandler.AddNotification(new CommandValidationErrorNotification(error.ErrorMessage));
                }

                return true;
            }

            return false;
        }
    }
}
