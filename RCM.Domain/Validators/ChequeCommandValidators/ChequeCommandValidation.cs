using FluentValidation;
using RCM.Domain.Commands.ChequeCommands;
using System;

namespace RCM.Domain.Validators.ChequeCommandValidators
{
    public abstract class ChequeCommandValidator<T> : AbstractValidator<T> where T : ChequeCommand
    {
        protected void ValidateId()
        {
            RuleFor(ch => ch.Id)
                .NotEmpty()
                .WithMessage("O Id do cheque não pode estar vazio.");
        }

        protected void ValidateBancoId()
        {
            RuleFor(ch => ch.BancoId)
                .NotEmpty()
                .WithMessage("O cheque deve estar relacionado a um banco.");
        }

        protected void ValidateAgencia()
        {
            RuleFor(ch => ch.Agencia)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(5)
                .WithMessage("A agência deve ter entre 4 e 5 caracteres e não deve estar vazio.");
        }

        protected void ValidateConta()
        {
            RuleFor(ch => ch.Conta)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(12)
                .WithMessage("A conta deve ter entre 6 e 10 caracteres e não deve estar vazio.");
        }

        protected void ValidateNumeroCheque()
        {
            RuleFor(ch => ch.NumeroCheque)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(8)
                .WithMessage("O número do cheque deve ter entre 6 e 8 caracteres e não pode estar vazio.");
        }

        protected void ValidateObservacao()
        {
            RuleFor(d => d.Observacao)
                .MaximumLength(1000)
                .WithMessage("O campo observação deve ter até 1000 caracteres.");
        }

        protected void ValidateClienteId()
        {
            RuleFor(ch => ch.ClienteId)
                .NotEmpty()
                .WithMessage("O cheque deve estar relacionado a um cliente.");
        }

        protected void ValidateDataEmissao()
        {
            RuleFor(ch => ch.DataEmissao)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de emissão deve estar em um formato válido.");
        }

        protected void ValidateDataVencimento()
        {
            RuleFor(ch => ch.DataVencimento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao)
                .WithMessage("A data de vencimento deve estar em um formato válido.");
        }

        protected void ValidateValor()
        {
            RuleFor(ch => ch.Valor)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor do cheque deve ser maior que 0.");
        }
        
        protected void ValidateDataCompensacao()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataVencimento)
                .WithMessage("A data da compensação deve ser maior que a data de vencimento.");
        }

        protected void ValidateDataRepasse()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao)
                .WithMessage("A data do repasse deve ser maior que a data de emissão.");
        }

        protected void ValidateDataSusto()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataEmissao)
                .WithMessage("A data do susto deve ser maior que a data de emissao.");
        }

        protected void ValidateDataDevolucao()
        {
            RuleFor(ch => ch.DataEvento)
                .NotEmpty()
                .GreaterThanOrEqualTo(d => d.DataVencimento)
                .WithMessage("A data de devolução deve ser maior que a data de vencimento.");
        }

        protected void ValidateMotivo()
        {
            RuleFor(ch => ch.Motivo)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("O campo motivo deve ter até 100 caracteres e não deve estar em branco.");
        }
    }
}
