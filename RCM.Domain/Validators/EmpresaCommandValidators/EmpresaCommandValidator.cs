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
            ValidateContatoNotEmpty();
            ValidateContatoTelefoneResidencial();
        }

        private void ValidateContatoNotEmpty()
        {
            RuleFor(c => this)
                .Must((c, m) => ValidateContatoProperties(c))
                .WithMessage("Você deve preencher pelo menos um dos meios de contato.");
        }

        private void ValidateContatoTelefoneResidencial()
        {
            RuleSet("Contato", () =>
            {
                RuleFor(c => c.ContatoEmail)
                    .EmailAddress()
                    .MaximumLength(100)
                    .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");

                RuleFor(c => c.ContatoTelefoneResidencial)
                    .MaximumLength(15)
                    .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");

                RuleFor(c => c.ContatoTelefoneComercial)
                    .MaximumLength(15)
                    .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");

                RuleFor(c => c.ContatoCelular)
                    .MaximumLength(15)
                    .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");

                RuleFor(c => c.ContatoObservacao)
                    .MaximumLength(250)
                    .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
            }); 
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
            ValidateCNPJ();
            ValidateInscricaoEstadual();
        }

        private void ValidateCNPJ()
        {
            RuleFor(c => c.DocumentoCadastroNacional)
                .NotEmpty()
                .MaximumLength(14)
                .MaximumLength(14)
                .WithMessage("O CNPJ deve ter 14 caracteres e não deve estar vazio.");
        }

        private void ValidateInscricaoEstadual()
        {
            RuleFor(c => c.DocumentoCadastroEstadual)
                .MaximumLength(12)
                .WithMessage("A inscrição estadual deve até ter 12 caracteres.");
        }
        #endregion
    }
}
