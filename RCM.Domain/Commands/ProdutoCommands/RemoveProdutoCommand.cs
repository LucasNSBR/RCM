using RCM.Domain.Validators.ProdutoCommandValidators;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class RemoveProdutoCommand : ProdutoCommand
    {
        public RemoveProdutoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
