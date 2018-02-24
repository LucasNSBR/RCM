using RCM.Domain.Models;
using RCM.Domain.Validators.ChequeCommandValidators;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class AddChequeCommand : ChequeCommand
    {
        public AddChequeCommand(Cheque cheque) : base(cheque)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddChequeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
