using RCM.Domain.Validators.EmpresaCommandValidators;
using System;

namespace RCM.Domain.Commands.EmpresaCommands
{
    public class AddOrUpdateEmpresaCommand : EmpresaCommand
    {
        public AddOrUpdateEmpresaCommand(Guid id, string razaoSocial, string nomeFantasia, string descricao)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Descricao = descricao;
        }

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

        public override bool IsValid()
        {
            ValidationResult = new AddOrUpdateEmpresaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
