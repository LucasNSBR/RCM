using RCM.Domain.Models;
using RCM.Domain.Validators.BancoCommandValidators;

namespace RCM.Domain.Commands.BancoCommands
{
    public class RemoveBancoCommand : BancoCommand
    {
        public RemoveBancoCommand(Banco banco) : base(banco)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
