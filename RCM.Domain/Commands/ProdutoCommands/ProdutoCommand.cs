using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Request
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Aplicacao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
