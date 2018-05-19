using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public class DevolverChequeCommandValidator : ChequeCommandValidator<DevolverChequeCommand>
    {
        public DevolverChequeCommandValidator()
        {
            ValidateId();
            ValidateDataDevolucao();
            ValidateMotivo();
        }

        private void ValidateDataDevolucao()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataVencimento);
        }
    }
}
