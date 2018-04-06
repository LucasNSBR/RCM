using RCM.Domain.Validators.OrdemServicoCommandValidators;
using System;

namespace RCM.Domain.Commands.OrdemServicoCommands
{
    public class RemoveOrdemServicoCommand : OrdemServicoCommand
    {
        public RemoveOrdemServicoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrdemServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
