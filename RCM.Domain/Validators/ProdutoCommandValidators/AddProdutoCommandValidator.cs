using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class AddProdutoCommandValidator : ProdutoCommandValidator<AddProdutoCommand>
    {
        public AddProdutoCommandValidator()
        {
            ValidateNome();
            ValidateEstoque();
            ValidateEstoqueIdeal();
            ValidateEstoqueLocalizacao();
            ValidatePrecoVenda();
        }
    }
}
