using RCM.Domain.Core.Commands;
using RCM.Domain.Core.Errors;
using RCM.Domain.Core.MediatorServices;
using RCM.Domain.Core.Models;
using RCM.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Domain.CommandHandlers
{
    public abstract class CommandHandler<TModel> where TModel : Entity<TModel>
    {
        protected readonly IMediatorHandler _mediator;
        protected readonly IUnitOfWork _unitOfWork;
        protected CommandResult _commandResponse;

        public CommandHandler(IMediatorHandler mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;

            _commandResponse = new CommandResult();
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
                    _commandResponse.AddError(new CommandError("Commit Error", error?.InnerException?.Message ?? error.Message));
                }
            }

            return false;
        }

        protected bool NotifyModelErrors(IReadOnlyList<DomainError> errors)
        {
            if (!errors.Any())
                return false;

            foreach (var error in errors.ToList())
            {
                _commandResponse.AddError(new DomainError(error.Code, error.Description));
            }

            return true;
        }

        protected void NotifyCommandError(string errorMessage, string errorCode = null)
        {
            _commandResponse.AddError(new CommandError(errorMessage, errorCode));
        }

        protected void NotifyCommandErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _commandResponse.AddError(new CommandError(error.ErrorMessage, error.ErrorCode));
            }
        }

        protected Task<CommandResult> Response()
        {
            return Task.FromResult(_commandResponse);
        }
    }
}
