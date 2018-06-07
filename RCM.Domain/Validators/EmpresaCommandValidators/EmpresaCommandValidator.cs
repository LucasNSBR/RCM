using FluentValidation;
using RCM.Domain.Commands.EmpresaCommands;

namespace RCM.Domain.Validators.EmpresaCommandValidators
{
    public class EmpresaCommandValidator<T> : AbstractValidator<T> where T : EmpresaCommand
    {
        protected void ValidateLogo()
        {
            RuleFor(e => e.Logo)
                .NotEmpty();
        }

        protected void ValidateRazaoSocial()
        {
            RuleFor(e => e.RazaoSocial)
                .NotEmpty()
                .Length(10, 100);
        }

        protected void ValidateNomeFantasia()
        {
            RuleFor(e => e.NomeFantasia)
                .NotEmpty()
                .Length(10, 100);
        }

        protected void ValidateDescricao()
        {
            RuleFor(e => e.Descricao)
                .MaximumLength(1000);
        }

        #region Contato
        protected void ValidateContato()
        {
            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .NotEmpty()
                .Length(15, 100);

            RuleFor(c => c.ContatoTelefoneResidencial)
                .NotEmpty()
                .Length(8, 15);

            RuleFor(c => c.ContatoTelefoneComercial)
                .NotEmpty()
                .Length(8, 15);

            RuleFor(c => c.ContatoCelular)
                .NotEmpty()
                .Length(8, 15);

            RuleFor(c => c.ContatoObservacao)
                .MaximumLength(250);
        }
        #endregion

        #region Endereco
        protected void ValidateEndereco()
        {
            RuleFor(c => c.EnderecoNumero)
                .ExclusiveBetween(0, 9999);

            RuleFor(c => c.EnderecoRua)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(c => c.EnderecoBairro)
                .NotEmpty()
                .Length(3, 25);

            RuleFor(c => c.EnderecoComplemento)
                .MaximumLength(250);

            RuleFor(c => c.EnderecoCidadeId)
                .NotEmpty();

            RuleFor(c => c.EnderecoCEP)
                .NotEmpty()
                .Length(8);
        }
        #endregion

        #region Documento
        protected void ValidateDocumento()
        {
            RuleFor(c => c.DocumentoCadastroNacional)
                .NotEmpty()
                .Length(14);

            RuleFor(c => c.DocumentoCadastroEstadual)
                .NotEmpty()
                .Length(13);
        }
        #endregion
    }
}
