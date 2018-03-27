using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ProdutoModels;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand : Command
    {
        public Produto Produto { get; }

        public ProdutoCommand(Produto produto)
        {
            Produto = produto;
        }
    }
}
