using RCM.Domain.Commands.FornecedorCommands;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public class UpdateFornecedorCommandValidator : FornecedorCommandValidator<UpdateFornecedorCommand>
    {
        public UpdateFornecedorCommandValidator()
        {
            ValidateId();
            ValidateNome();
            ValidateDescricao();
            ValidateContato();
            ValidateEndereco();
            ValidateDocumento();
        }
    }
}
