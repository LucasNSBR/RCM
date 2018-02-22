using RCM.Domain.Models;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class AddFornecedorCommand : FornecedorCommand
    {
        public AddFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
