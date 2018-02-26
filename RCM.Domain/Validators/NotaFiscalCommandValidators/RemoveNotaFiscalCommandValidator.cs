using RCM.Domain.Commands.NotaFiscalCommands;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public class RemoveNotaFiscalCommandValidator : NotaFiscalCommandValidator<NotaFiscalCommand>
    {
        public RemoveNotaFiscalCommandValidator()
        {
            ValidateId();
        }
    }
}
