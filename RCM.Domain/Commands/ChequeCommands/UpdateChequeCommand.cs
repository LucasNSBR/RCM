using RCM.Domain.Models;
using RCM.Domain.Validators.ChequeCommandValidators;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class UpdateChequeCommand : ChequeCommand
    {
        public UpdateChequeCommand(Cheque cheque) : base(cheque)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
