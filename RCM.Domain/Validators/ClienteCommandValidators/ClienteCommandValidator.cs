using FluentValidation;
using RCM.Domain.Commands.ClienteCommands;

namespace RCM.Domain.Validators.ClienteCommandValidators
{
    public abstract class ClienteCommandValidator<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O Id do cliente não deve estar vazio.");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100)
                .WithMessage("O nome do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .MaximumLength(1000)
                .WithMessage("A descrição do cliente deve ter até 1000 caracteres.");
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

        protected void ValidateContatoNotEmpty()
        {
            RuleFor(c => this)
                .Must((c, m) => ValidateContatoProperties(c))
                .WithMessage("Você deve preencher pelo menos um dos meios de contato.");
        }

        protected void ValidateContatoEmail()
        {
            RuleFor(c => c.ContatoEmail)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        protected void ValidateContatoTelefoneResidencial()
        {
            RuleFor(c => c.ContatoTelefoneResidencial)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateContatoTelefoneComercial()
        {
            RuleFor(c => c.ContatoTelefoneComercial)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateContatoCelular()
        {
            RuleFor(c => c.ContatoCelular)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        protected void ValidateContatoObservacao()
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

        protected void ValidateEnderecoNumero()
        {
            RuleFor(c => c.EnderecoNumero)
                .ExclusiveBetween(0, 9999)
                .WithMessage("O número do endereço deve estar em um formato válido.");
        }

        protected void ValidateEnderecoRua()
        {
            RuleFor(c => c.EnderecoRua)
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("O nome da rua deve ter entre 3 caracteres e 100 e não pode estar vazio.");
        }

        protected void ValidateEnderecoBairro()
        {
            RuleFor(c => c.EnderecoBairro)
                .MinimumLength(3)
                .MaximumLength(25)
                .WithMessage("O nome do bairro deve ter entre 3 e 25 caracteres e não pode estar vazio.");
        }

        protected void ValidateEnderecoComplemento()
        {
            RuleFor(c => c.EnderecoComplemento)
                .MaximumLength(250)
                .WithMessage("O complemento do endereço deve ter até 250 caracteres e não pode estar vazio");
        }

        protected void ValidateEnderecoCEP()
        {
            RuleFor(c => c.EnderecoCEP)
                .MaximumLength(8)
                .WithMessage("O CEP do endereço deve ter 8 caracteres.");
        }
        #endregion

        #region Documento
        protected void ValidateDocumento()
        {
            ValidateCPF();
            ValidateRG();
        }

        protected void ValidateCPF()
        {
            RuleFor(c => c.DocumentoCadastroNacional)
                .NotEmpty()
                .MaximumLength(11)
                .MaximumLength(11)
                .WithMessage("O CPF deve ter 11 caracteres e não deve estar vazio.");
        }

        protected void ValidateRG()
        {
            RuleFor(c => c.DocumentoCadastroEstadual)
                .MaximumLength(10)
                .WithMessage("O RG deve até ter 10 caracteres.");
        }
        #endregion
    }
}
