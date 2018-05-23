using FluentValidation;
using RCM.Domain.Commands.FornecedorCommands;
using RCM.Domain.Models.FornecedorModels;

namespace RCM.Domain.Validators.FornecedorCommandValidators
{
    public abstract class FornecedorCommandValidator<T> : AbstractValidator<T> where T: FornecedorCommand
    {
        protected void ValidateId()
        {
            RuleFor(f => f.Id)
                .NotEmpty();
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Nome)
               .NotEmpty()
               .Length(10, 100);
        }

        protected void ValidateDescricao()
        {
            RuleFor(f => f.Observacao)
                .MaximumLength(1000);
        }

        #region Contato
        protected void ValidateContato()
        {
            RuleFor(c => c.ContatoEmail)
                .NotEmpty()
                .EmailAddress()
                .Length(15, 100);

            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15);

            RuleFor(c => c.ContatoTelefoneComercial)
                .NotEmpty()
                .Length(8, 15);
            
            RuleFor(c => c.ContatoCelular)
                .MaximumLength(15);

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
                .Length(3, 25);

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
            RuleFor(f => f)
                .Must(command => ValidateDocumentoCadastroNacional(command))
                .WithMessage("O CPF/CNPJ deve estar em um formato válido.");

            RuleFor(f => f)
                .Must(command => ValidateDocumentoCadastroEstadual(command))
                .WithMessage("O RG/Inscrição Estadual deve estar em um formato válido.");
        }

        private bool ValidateDocumentoCadastroNacional(FornecedorCommand command)
        {
            var length = command.DocumentoCadastroNacional.Length;
            
            if (command.Tipo == FornecedorTipoEnum.PessoaFisica)
                return length == 11;
            else
                return length == 14;
        }

        private bool ValidateDocumentoCadastroEstadual(FornecedorCommand command)
        {
            var length = command.DocumentoCadastroEstadual.Length;

            if (command.Tipo == FornecedorTipoEnum.PessoaFisica)
                return length <= 12;
            else
                return length > 12 && length <= 14;
        }
        #endregion
    }
}
