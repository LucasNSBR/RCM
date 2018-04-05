using RCM.Domain.Validators.NotaFiscalCommandValidators;
using System;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class RemoveNotaFiscalCommand : NotaFiscalCommand
    {
        public RemoveNotaFiscalCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
