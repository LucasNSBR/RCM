using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class AttachVendaProdutoCommandValidator : VendaCommandValidator<AttachVendaProdutoCommand>
    {
        public AttachVendaProdutoCommandValidator()
        {
            ValidateDesconto();
            ValidateProdutoId();
            ValidateQuantidade();
        }

        #region Desconto
        private void ValidateDesconto()
        {
            RuleFor(pv => pv.Desconto)
                .Must((pv, d) => ValidateDesconto(pv));
        }

        private bool ValidateDesconto(AttachVendaProdutoCommand command)
        {
            return command.Desconto < command.PrecoVenda;
        }
        #endregion

        private void ValidateProdutoId()
        {
            RuleFor(pv => pv.ProdutoId)
                .NotEmpty();
        }

        private void ValidateQuantidade()
        {
            RuleFor(pv => pv.Quantidade)
                .InclusiveBetween(1, 100);
        }
    }
}
