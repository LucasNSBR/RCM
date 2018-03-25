using RCM.Domain.Models.BancoModels;
using RCM.Domain.Validators.BancoCommandValidators;

namespace RCM.Domain.Commands.BancoCommands
{
    public class AddBancoCommand : BancoCommand
    {
        public AddBancoCommand(Banco banco) : base(banco)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddBancoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
