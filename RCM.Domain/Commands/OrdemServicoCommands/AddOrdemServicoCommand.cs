using RCM.Domain.Models.ProdutoModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Commands.OrdemServicoCommands
{
    public class AddOrdemServicoCommand : OrdemServicoCommand
    {
        private Func<object, System.Linq.Expressions.Expression<Func<Produto, object>>[], System.Linq.IQueryable<Produto>> projectTo;

        public AddOrdemServicoCommand(Guid clienteId, List<Produto> produtos)
        {
            ClienteId = clienteId;
            Produtos = produtos;
        }

        public AddOrdemServicoCommand(Guid clienteId, Func<object, System.Linq.Expressions.Expression<Func<Produto, object>>[], System.Linq.IQueryable<Produto>> projectTo)
        {
            ClienteId = clienteId;
            this.projectTo = projectTo;
        }
    }
}
