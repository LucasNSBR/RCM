using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public class RemoveBancoCommandValidator : BancoCommandValidator<RemoveBancoCommand>
    {
        public RemoveBancoCommandValidator()
        {
            ValidateId();
        }
    }
}
