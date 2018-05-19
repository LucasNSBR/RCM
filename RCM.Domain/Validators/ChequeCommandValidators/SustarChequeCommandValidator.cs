using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class SustarChequeCommandValidator : ChequeCommandValidator<SustarChequeCommand>
    {
        public SustarChequeCommandValidator()
        {
            ValidateId();
            ValidateDataSusto();
            ValidateMotivo();
        }

        private void ValidateDataSusto()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao);
        }
    }
}
