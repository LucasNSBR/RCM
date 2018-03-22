using RCM.Domain.Core.Commands;
using RCM.Domain.Models;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public abstract class FornecedorCommand : Command
    {
        public Fornecedor Fornecedor { get; }

        public FornecedorCommand(Fornecedor fornecedor) 
        {
            Fornecedor = fornecedor;
        }
    }
}
