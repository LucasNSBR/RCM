using RCM.Domain.Models;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class UpdateFornecedorCommand : FornecedorCommand
    {
        public UpdateFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }
    }
}
