using RCM.Domain.Models;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class RemoveFornecedorCommand : FornecedorCommand
    {
        public RemoveFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
