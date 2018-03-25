using RCM.Domain.Models.FornecedorModels;
using RCM.Domain.Validators.FornecedorCommandValidators;

namespace RCM.Domain.Commands.FornecedorCommands
{
    public class UpdateFornecedorCommand : FornecedorCommand
    {
        public UpdateFornecedorCommand(Fornecedor fornecedor) : base(fornecedor)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFornecedorCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
