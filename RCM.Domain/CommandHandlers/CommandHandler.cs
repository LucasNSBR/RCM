using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Core.Models;
using RCM.Domain.Repositories;
using RCM.Domain.UnitOfWork;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers
{
    public abstract class CommandHandler<TModel> where TModel : Entity<TModel>
    {
        protected readonly IMediatorHandler _mediator;
        protected readonly IBaseRepository<TModel> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected RequestResponse _commandResponse;

        public CommandHandler(IMediatorHandler mediator, IBaseRepository<TModel> baseRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;

            _commandResponse = new RequestResponse();
        }

        protected bool Commit()
        {
            var commitResult = _unitOfWork.Commit();
            
            if (commitResult.Success)
                return true;
            else
            {
                foreach (var error in commitResult.Errors)
                {
                    _commandResponse.AddError(new RequestError("Commit Error", error.Message ?? error.InnerException.Message));
                }
            }

            return false;
        }
        
        protected void NotifyRequestErrors(Request request)
        {
            foreach (var error in request.ValidationResult.Errors)
            {
                _commandResponse.AddError(new RequestError(error.ErrorCode, error.ErrorMessage));
            }
        }

        protected Task<RequestResponse> Response()
        {
            return Task.FromResult(_commandResponse);
        }
    }
}
