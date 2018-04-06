using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Models.OrdemServicoModels;
using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Commands.OrdemServicoCommands
{
    public abstract class OrdemServicoCommand : Request
    {
        public Guid Id { get; set; }
        public OrdemServicoStatus Status { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public decimal Total { get; set; }
    }
}
