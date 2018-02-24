using FluentValidation.Results;
using RCM.Domain.Models;
using RCM.Domain.Validators.BancoCommandValidators;

namespace RCM.Domain.Commands.BancoCommands
{
    public class UpdateBancoCommand : BancoCommand
    {
        public UpdateBancoCommand(Banco banco) : base(banco)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
