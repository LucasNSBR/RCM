using RCM.Domain.Models;
using RCM.Domain.Validators.FornecedorCommandValidators;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class RemoveFornecedorCommand : FornecedorCommand
    {
        public RemoveFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
