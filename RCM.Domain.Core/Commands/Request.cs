using FluentValidation.Results;
using MediatR;

namespace RCM.Domain.Core.Commands
{
    public abstract class Request : IRequest<RequestResponse>
    {
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();
    }
}
