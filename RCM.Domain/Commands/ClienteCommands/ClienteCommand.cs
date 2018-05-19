using RCM.Domain.Core.Commands;
using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Domain.Commands.ClienteCommands
{
    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ClienteTipoEnum Tipo { get; set; }
        public ClientePontuacaoEnum Pontuacao { get; set; }
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

        public void AttachContato(string contatoCelular, string contatoEmail, string contatoTelefoneComercial, string contatoTelefoneResidencial, string contatoObservacao)
        {
            ContatoCelular = contatoCelular;
            ContatoEmail = contatoEmail;
            ContatoTelefoneComercial = contatoTelefoneComercial;
            ContatoTelefoneResidencial = contatoTelefoneResidencial;
            ContatoObservacao = contatoObservacao;
        }

        public void AttachEndereco(int enderecoNumero, string enderecoRua, string enderecoBairro, string enderecoComplemento, Guid enderecoCidadeId, string enderecoCEP)
        {
            EnderecoNumero = enderecoNumero;
            EnderecoRua = enderecoRua;
            EnderecoBairro = enderecoBairro;
            EnderecoComplemento = enderecoComplemento;
            EnderecoCidadeId = enderecoCidadeId;
            EnderecoCEP = enderecoCEP;
        }

        public void AttachDocumento(string documentoCadastroNacional, string documentoCadastroEstadual)
        {
            DocumentoCadastroNacional = documentoCadastroNacional;
            DocumentoCadastroEstadual = documentoCadastroEstadual;
        }
    }
}
