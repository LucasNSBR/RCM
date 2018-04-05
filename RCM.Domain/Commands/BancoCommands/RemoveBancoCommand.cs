using RCM.Domain.Validators.BancoCommandValidators;
using System;

namespace RCM.Domain.Commands.BancoCommands
{
    public class RemoveBancoCommand : BancoCommand
    {
        public RemoveBancoCommand(Guid id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
