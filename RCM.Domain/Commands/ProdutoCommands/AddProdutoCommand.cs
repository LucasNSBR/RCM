using RCM.Domain.Validators.ProdutoCommandValidators;

namespace RCM.Domain.Commands.ProdutoCommands
{
    public class AddProdutoCommand : ProdutoCommand
    {
        public AddProdutoCommand(string nome, string aplicacao, int quantidade, decimal precoVenda)
        {
            Nome = nome;
            Aplicacao = aplicacao;
            Quantidade = quantidade;
            PrecoVenda = precoVenda;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
