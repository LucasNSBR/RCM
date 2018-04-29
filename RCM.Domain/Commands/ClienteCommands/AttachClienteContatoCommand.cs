using RCM.Domain.Validators.ClienteCommandValidators;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class AttachClienteContatoCommand : ClienteCommand
    {
        public string Email { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneComercial { get; set; }
        public string Celular { get; set; }
        public string Observacao { get; set; }

        public AttachClienteContatoCommand(Guid id, string email, string telefoneResidencial, string telefoneComercial, string celular, string observacao)
        {
            Id = id;
            Email = email;
            TelefoneResidencial = telefoneResidencial;
            TelefoneComercial = telefoneComercial;
            Celular = celular;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new AttachClienteContatoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
