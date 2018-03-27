using RCM.Domain.Models.ProdutoModels;
using RCM.Domain.Validators.ProdutoCommandValidators;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class RemoveProdutoCommand : ProdutoCommand
    {
        public RemoveProdutoCommand(Produto produto) : base(produto)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
