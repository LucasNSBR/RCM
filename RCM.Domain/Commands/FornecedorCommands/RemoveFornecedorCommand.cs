using RCM.Domain.Validators.FornecedorCommandValidators;
using System;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class RemoveFornecedorCommand : FornecedorCommand
    {
        public RemoveFornecedorCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
