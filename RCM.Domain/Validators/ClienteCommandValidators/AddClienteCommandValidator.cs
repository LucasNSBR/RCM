using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public class AddClienteCommandValidator : ClienteCommandValidator<AddClienteCommand>
    {
        public AddClienteCommandValidator()
        {
            ValidateNome();
            ValidateDescricao();
            ValidateContatoNotEmpty();
            ValidateContatoEmail();
            ValidateContatoCelular();
            ValidateContatoTelefoneComercial();
            ValidateTelefoneResidencial();
            ValidateContatoObservacao();
        }
    }
}
