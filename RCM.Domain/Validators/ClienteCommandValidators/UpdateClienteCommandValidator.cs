using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public class UpdateClienteCommandValidator : ClienteCommandValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            ValidateId();
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
