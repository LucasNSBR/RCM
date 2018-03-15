using RCM.Domain.Core.Commands;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Diagnostics;
using System.Linq;

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
                    _domainNotificationHandler.AddNotification(new CommitErrorDomainNotification(error.InnerException.Message));
                }

                if (!commandResult.Errors.Any())
                    _domainNotificationHandler.AddNotification(new CommitErrorDomainNotification("Erro desconhecido"));
            }

            return false;
        }

        protected bool Valid(Command command)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    _domainNotificationHandler.AddNotification(new CommandValidationErrorDomainNotification("COMMAND VALIDATION ERROR", error.ErrorMessage));
                }

                return false;
            }

            return true;
        }
    }
}
