using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class RepassarChequeCommandValidator : ChequeCommandValidator<RepassarChequeCommand>
    {
        public RepassarChequeCommandValidator()
        {
            ValidateId();
            ValidateRepasseFornecedorId();
            ValidateDataRepasse();
        }

        private void ValidateRepasseFornecedorId()
        {
            RuleFor(ch => ch.FornecedorRepassadoId)
                .NotEmpty();
        }

        private void ValidateDataRepasse()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao);
        }
    }
}
