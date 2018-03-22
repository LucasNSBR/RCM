using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public class AddBancoCommandValidator : BancoCommandValidator<AddBancoCommand>
    {
        public AddBancoCommandValidator()
        {
            ValidateCodigoCompensacao();
            ValidateName();
        }
    }
}
