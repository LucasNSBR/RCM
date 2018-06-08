using FluentValidation;
using RCM.Domain.Commands.VendaCommands;

namespace RCM.Domain.Validators.VendaCommandValidators
{
    public class AttachVendaServicoCommandValidator : VendaCommandValidator<AttachVendaServicoCommand>
    {
        public AttachVendaServicoCommandValidator()
        {
            ValidateVendaId();
            ValidateServicoDetalhes();
            ValidateServicoPreco();
        }

        private void ValidateServicoDetalhes()
        {
            RuleFor(s => s.ServicoDetalhes)
                .NotEmpty()
                .MaximumLength(250);
        }

        private void ValidateServicoPreco()
        {
            RuleFor(s => s.ServicoPreco)
                .NotEmpty();
        }
    }
}
