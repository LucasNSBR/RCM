using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public decimal PrecoVenda { get; set; }
        public Guid MarcaId { get; set; }
    }
}
