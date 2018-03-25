using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Validators.NotaFiscalCommandValidators;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class RemoveNotaFiscalCommand : NotaFiscalCommand
    {
        public RemoveNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
