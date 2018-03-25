using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Validators.NotaFiscalCommandValidators;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class AddNotaFiscalCommand : NotaFiscalCommand
    {
        public AddNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
