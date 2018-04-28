using RCM.Domain.Validators.ClienteCommandValidators;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class AttachClienteContatoCommand : ClienteCommand
    {
        public string Email { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneComercial { get; set; }
        public string Celular { get; set; }
        public string Observacao { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AttachClienteContatoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
