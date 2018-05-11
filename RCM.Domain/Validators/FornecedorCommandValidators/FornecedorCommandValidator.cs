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
                .NotEmpty()
                .WithMessage("O Id do fornecedor não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(f => f.Nome)
               .NotEmpty()
               .MinimumLength(10)
               .MaximumLength(100)
               .WithMessage("O nome do fornecedor deve ter entre 10 e 100 caracteres e não pode estar vazio.");
        }

        protected void ValidateObservacao()
        {
            RuleFor(f => f.Observacao)
                .MaximumLength(1000)
                .WithMessage("O campo observação deve ter até 1000 caracteres.");
        }

        #region Contato
        protected void ValidateContato()
        {
            ValidateContatoNotEmpty();
            ValidateContatoEmail();
            ValidateContatoCelular();
            ValidateContatoTelefoneComercial();
            ValidateContatoTelefoneResidencial();
            ValidateContatoObservacao();
        }

        private void ValidateContatoNotEmpty()
        {
            RuleFor(c => this)
                .Must((c, m) => ValidateContatoProperties(c))
                .WithMessage("Você deve preencher pelo menos um dos meios de contato.");
        }

        private void ValidateContatoEmail()
        {
            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneResidencial()
        {
            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneComercial()
        {
            RuleFor(c => c.ContatoTelefoneComercial)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoCelular()
        {
            RuleFor(c => c.ContatoCelular)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoObservacao()
        {
            RuleFor(c => c.ContatoObservacao)
                .MaximumLength(250)
                .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
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
            ValidateEnderecoNumero();
            ValidateEnderecoRua();
            ValidateEnderecoBairro();
            ValidateEnderecoComplemento();
            ValidateEnderecoCEP();
        }

        private void ValidateEnderecoNumero()
        {
            RuleFor(c => c.EnderecoNumero)
                .ExclusiveBetween(0, 9999)
                .WithMessage("O número do endereço deve estar em um formato válido.");
        }

        private void ValidateEnderecoRua()
        {
            RuleFor(c => c.EnderecoRua)
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("O nome da rua deve ter entre 3 caracteres e 100 e não pode estar vazio.");
        }

        private void ValidateEnderecoBairro()
        {
            RuleFor(c => c.EnderecoBairro)
                .MinimumLength(3)
                .MaximumLength(25)
                .WithMessage("O nome do bairro deve ter entre 3 e 25 caracteres e não pode estar vazio.");
        }

        private void ValidateEnderecoComplemento()
        {
            RuleFor(c => c.EnderecoComplemento)
                .MaximumLength(250)
                .WithMessage("O complemento do endereço deve ter até 250 caracteres e não pode estar vazio");
        }

        private void ValidateEnderecoCEP()
        {
            RuleFor(c => c.EnderecoCEP)
                .MaximumLength(8)
                .WithMessage("O CEP do endereço deve ter 8 caracteres.");
        }
        #endregion

        #region Documento
        protected void ValidateDocumento()
        {
            RuleFor(f => f.DocumentoCadastroNacional)
                .NotEmpty()
                .Must((command, property) => ValidateDocumentoCadastroNacional(command))
                .WithMessage("O CPF/CNPJ deve estar em um formato válido.");

            RuleFor(f => f.DocumentoCadastroEstadual)
                .Must((command, property) => ValidateDocumentoCadastroEstadual(command))
                .WithMessage("O RG/Inscrição Estadual deve estar em um formato válido.");
        }

        private bool ValidateDocumentoCadastroNacional(FornecedorCommand command)
        {
            if (command.DocumentoCadastroNacional == null)
                return false;

            if (command.Tipo == FornecedorTipoEnum.PessoaFisica)
                return command.DocumentoCadastroNacional.Length == 11;
            else
                return command.DocumentoCadastroNacional.Length == 14;
        }

        private bool ValidateDocumentoCadastroEstadual(FornecedorCommand command)
        {
            if (command.DocumentoCadastroEstadual == null || string.IsNullOrEmpty(command.DocumentoCadastroEstadual))
                return true;

            var length = command.DocumentoCadastroEstadual.Length;

            if (command.Tipo == FornecedorTipoEnum.PessoaFisica)
                return length <= 12;
            else
                return length > 12 && length <= 14;
        }
        #endregion
    }
}
