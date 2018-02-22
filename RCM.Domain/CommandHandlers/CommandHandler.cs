using RCM.Domain.Core.MediatorServices;
using RCM.Domain.DomainNotificationHandlers;
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
        private IMediatorHandler mediator;
        private IDuplicataRepository duplicataRepository;
        private IUnitOfWork unitOfWork;

        public CommandHandler(IMediatorHandler mediator, IBaseRepository<TModel> baseRepository, IUnitOfWork unitOfWork, IDomainNotificationHandler domainNotificationHandler)
        {
            _mediator = mediator;
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected bool Commit()
        {
            if (_unitOfWork.Commit() && _domainNotificationHandler.IsEmpty())
                return true;

            return false;
        }

        protected void NotifyPropertyErrors()
        {
        }
    }
}
