using RCM.Domain.Commands.BancoCommands;

namespace RCM.Domain.Validators.BancoCommandValidators
{
    public class UpdateBancoCommandValidator : BancoCommandValidator<UpdateBancoCommand>
    {
        public UpdateBancoCommandValidator()
        {
            ValidateId();
            ValidateCodigoCompensacao();
            ValidateName();
        }
    }
}
