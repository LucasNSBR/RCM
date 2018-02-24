using FluentValidation;
using RCM.Domain.Commands.NotaFiscalCommands;

namespace RCM.Domain.Validators.NotaFiscalCommandValidators
{
    public class RemoveNotaFiscalCommandValidator : NotaFiscalCommandValidator<NotaFiscalCommand>
    {
        public RemoveNotaFiscalCommandValidator()
        {
            RuleFor(n => n.NotaFiscal.Id)
                .NotEmpty()
                .WithMessage("O Id da nota fiscal não deve estar em branco.");
        }
    }
}
