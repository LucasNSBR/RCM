using RCM.Domain.Models.ClienteModels;
using RCM.Domain.Validators.ClienteCommandValidators;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Guid id, string nome, ClientePontuacaoEnum pontuacao, string descricao) 
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Pontuacao = pontuacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
