using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ChequeCommands
{
    public abstract class ChequeCommand : Request
    {
        public Guid Id { get; set; }
        public Guid BancoId { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string NumeroCheque { get; set; }
        public string Observacao { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
    }
}
