using RCM.Domain.Models;
using RCM.Domain.Validators.ChequeCommandValidators;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class RemoveChequeCommand : ChequeCommand
    {
        public RemoveChequeCommand(Cheque cheque) : base(cheque)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
