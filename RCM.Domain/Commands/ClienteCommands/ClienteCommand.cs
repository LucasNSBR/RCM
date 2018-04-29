using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string ContatoCelular { get; set; }
        public string ContatoEmail { get; set; }
        public string ContatoTelefoneResidencial { get; set; }
        public string ContatoTelefoneComercial { get; set; }
        public string ContatoObservacao { get; set; }

        public void AttachContato(string contatoCelular, string contatoEmail, string contatoTelefoneComercial, string contatoTelefoneResidencial, string contatoObservacao)
        {
            ContatoCelular = contatoCelular;
            ContatoEmail = contatoEmail;
            ContatoTelefoneComercial = contatoTelefoneComercial;
            ContatoTelefoneResidencial = contatoTelefoneResidencial;
            ContatoObservacao = contatoObservacao;
        }
    }
}
