using RCM.Domain.Validators.ChequeCommandValidators;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public class UpdateChequeCommand : ChequeCommand
    {
        public UpdateChequeCommand(Guid id, Guid bancoId, string agencia, string conta, string numeroCheque, string observacao, Guid clienteId, DateTime dataEmissao, DateTime dataVencimento, decimal valor)
        {
            Id = id;
            BancoId = bancoId;
            Agencia = agencia;
            Conta = conta;
            NumeroCheque = numeroCheque;
            Observacao = observacao;
            ClienteId = clienteId;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateChequeCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
