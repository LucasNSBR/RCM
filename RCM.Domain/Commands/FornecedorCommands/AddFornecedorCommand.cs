using RCM.Domain.Models;
using RCM.Domain.Validations.FornecedorCommandValidators;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class AddFornecedorCommand : FornecedorCommand
    {
        public AddFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new AddFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
