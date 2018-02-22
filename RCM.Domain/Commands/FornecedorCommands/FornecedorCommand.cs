using RCM.Domain.Core.Command;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public abstract class FornecedorCommand : Command
    {
        public Fornecedor Fornecedor { get; private set; }

        public FornecedorCommand(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
        }
    }
}
