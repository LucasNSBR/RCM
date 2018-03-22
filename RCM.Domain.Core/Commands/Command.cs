using FluentValidation.Results;
using RCM.Domain.Core.Models;

namespace RCM.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool IsValid();
    }
}
