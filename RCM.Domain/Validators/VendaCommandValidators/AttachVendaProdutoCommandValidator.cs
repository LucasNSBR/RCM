using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class AttachVendaProdutoCommandValidator : VendaCommandValidator<AttachVendaProdutoCommand>
    {
        public AttachVendaProdutoCommandValidator()
        {
            ValidateDesconto();
            ValidateAcrescimo();
            ValidateProdutoId();
            ValidateQuantidade();
        }

        #region Desconto
        private void ValidateDesconto()
        {
            RuleFor(pv => pv.Desconto)
                .NotEmpty()
                .Must((pv, d) => ValidateDesconto(pv))
                .WithMessage("O desconto deve estar em um formato válido.");
        }

        private bool ValidateDesconto(AttachVendaProdutoCommand command)
        {
            return command.Desconto < command.PrecoVenda;
        }
        #endregion

        private void ValidateAcrescimo()
        {
            RuleFor(pv => pv.Acrescimo)
                .NotEmpty()
                .WithMessage("O acréscimo deve estar em um formato válido.");
        }

        private void ValidateProdutoId()
        {
            RuleFor(pv => pv.ProdutoId)
                .NotEmpty()
                .WithMessage("O Id do produto não pode estar vazio.");
        }

        private void ValidateQuantidade()
        {
            RuleFor(pv => pv.Quantidade)
                .NotEmpty()
                .InclusiveBetween(0, 100)
                .WithMessage("A quantidade não pode estar vazia.");
        }
    }
}
