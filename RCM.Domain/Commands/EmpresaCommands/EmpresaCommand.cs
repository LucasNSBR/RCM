using RCM.Domain.Core.Commands;
using System;

namespace RCM.Domain.Commands.EmpresaCommands
{
    public abstract class EmpresaCommand : Command
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Descricao { get; set; }

        public string ContatoCelular { get; set; }
        public string ContatoEmail { get; set; }
        public string ContatoTelefoneResidencial { get; set; }
        public string ContatoTelefoneComercial { get; set; }
        public string ContatoObservacao { get; set; }

        public int EnderecoNumero { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoComplemento { get; set; }
        public Guid EnderecoCidadeId { get; set; }
        public string EnderecoCEP { get; set; }

        public string DocumentoCadastroNacional { get; set; }
        public string DocumentoCadastroEstadual { get; set; }
    }
}
