using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : LocalizedAbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty();
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .Length(8, 100);
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .MaximumLength(1000);
        }

        #region Contato
        protected void ValidateContato()
        {
            RuleFor(c => c)
                .Must((command) => ValidateContatoProperties(command))
                .WithMessage("Você deve fornecer pelo menos um meio de contato.");

            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15);

            RuleFor(c => c.ContatoCelular)
                .MaximumLength(15);

            RuleFor(c => c.ContatoTelefoneComercial)
                .MaximumLength(15);
            
            RuleFor(c => c.ContatoObservacao)
                .MaximumLength(250);
        }

        private bool ValidateContatoProperties(T command)
        {
            if (!string.IsNullOrWhiteSpace(command.ContatoCelular))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoTelefoneComercial))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoTelefoneResidencial))
                return true;
            if (!string.IsNullOrWhiteSpace(command.ContatoEmail))
                return true;

            return false;
        }
        #endregion

        #region Endereco
        protected void ValidateEndereco()
        {
            RuleFor(c => c.EnderecoNumero)
                .ExclusiveBetween(0, 9999);

            RuleFor(c => c.EnderecoRua)
                .MaximumLength(100);

            RuleFor(c => c.EnderecoBairro)
                .MaximumLength(25);

            RuleFor(c => c.EnderecoComplemento)
                .MaximumLength(250);

            RuleFor(c => c.EnderecoCidadeId)
                .NotEmpty();

            RuleFor(c => c.EnderecoCEP)
                .Length(8);
        }
        #endregion

        #region Documento
        protected void ValidateDocumento()
        {
            RuleFor(c => c)
                .Must(command => ValidateDocumentoCadastroNacional(command))
                .WithMessage("O CPF deve ter até 11 caracteres e CNPJ deve ter até 14 caracteres.");

            RuleFor(c => c)
                .Must(command => ValidateDocumentoCadastroEstadual(command))
                .WithMessage("O RG deve ter até 12 caracteres e Inscr. Estadual ter até 14 caracteres.");
        }

        private bool ValidateDocumentoCadastroNacional(ClienteCommand command)
        {
            if (command.DocumentoCadastroNacional == null)
                return true;

            if (command.Tipo == ClienteTipoEnum.PessoaFisica)
                return command.DocumentoCadastroNacional.Length == 11;
            else
                return command.DocumentoCadastroNacional.Length == 14;
        }

        private bool ValidateDocumentoCadastroEstadual(ClienteCommand command)
        {
            if (command.DocumentoCadastroEstadual == null)
                return true;

            var length = command.DocumentoCadastroEstadual.Length;
            
            if (command.Tipo == ClienteTipoEnum.PessoaFisica)
                return length <= 12;
            else
                return length > 12 && length <= 14;
        }
        #endregion
    }
}
