using FluentValidation.Results;
using MediatR;

namespace RCM.Domain.Core.Commands
{
    public abstract class Command : IRequest<CommandResult>
    {
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();
    }
}
