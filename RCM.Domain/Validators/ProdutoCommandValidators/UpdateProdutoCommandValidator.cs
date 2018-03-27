using RCM.Domain.Commands.ProdutoCommands;

namespace RCM.Domain.Validators.ProdutoCommandValidators
{
    public class UpdateProdutoCommandValidator : ProdutoCommandValidator<UpdateProdutoCommand>
    {
        public UpdateProdutoCommandValidator()
        {
            ValidateId();
            ValidateNome();
            ValidateAplicacao();
            ValidateQuantidade();
            ValidatePrecoVenda();
        }
    }
}
