using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Commands.NotaFiscalCommands
{
    public abstract class NotaFiscalCommand : Command
    {
        public Guid Id { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataChegada { get; set; }
        public decimal Valor { get; set; }
    }
}
