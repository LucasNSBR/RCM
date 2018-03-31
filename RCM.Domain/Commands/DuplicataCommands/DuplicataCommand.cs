using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.DuplicataCommands
{
    public abstract class DuplicataCommand : Command
    {
        public Guid Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Observacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid? NotaFiscalId { get; set; }
        public decimal Valor { get; set; }
    }
}
