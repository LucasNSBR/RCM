using RCM.Domain.Models.NotaFiscalModels;
using RCM.Domain.Validators.NotaFiscalCommandValidators;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public class UpdateNotaFiscalCommand : NotaFiscalCommand
    {
        public UpdateNotaFiscalCommand(NotaFiscal notaFiscal) : base(notaFiscal)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateNotaFiscalCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
