using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public class AttachClienteContatoCommandValidator : ClienteCommandValidator<AttachClienteContatoCommand>
    {
        private void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        private void ValidateTelefoneResidencial()
        {
            RuleFor(c => c.Celular)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateTelefoneComercial()
        {
            RuleFor(c => c.Celular)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateCelular()
        {
            RuleFor(c => c.Celular)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateObservacao()
        {
            RuleFor(c => c.Observacao)
                .MaximumLength(250)
                .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
        }

        public AttachClienteContatoCommandValidator()
        {
            ValidateCelular();
            ValidateEmail();
            ValidateTelefoneComercial();
            ValidateTelefoneResidencial();
            ValidateObservacao();
        }
    }
}
