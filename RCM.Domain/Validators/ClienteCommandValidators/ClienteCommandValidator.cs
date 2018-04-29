using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .MaximumLength(1000)
                .WithMessage("A descrição do cliente deve ter até 1000 caracteres.");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateTelefoneResidencial()
        {
            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateTelefoneComercial()
        {
            RuleFor(c => c.ContatoTelefoneComercial)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateCelular()
        {
            RuleFor(c => c.ContatoCelular)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateObservacao()
        {
            RuleFor(c => c.ContatoObservacao)
                .MaximumLength(250)
                .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
        }
    }
}
