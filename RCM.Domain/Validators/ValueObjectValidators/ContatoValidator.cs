using FluentValidation;

namespace RCM.Domain.Validators.ValueObjectValidators
{
    public class ContatoValidator<T> : LocalizedAbstractValidator<T>
    {
        public string ContatoCelular { get; private set; }
        public string ContatoEmail { get; private set; }
        public string ContatoTelefoneResidencial { get; private set; }
        public string ContatoTelefoneComercial { get; private set; }
        public string ContatoObservacao { get; private set; }

        public ContatoValidator(string contatoCelular, string contatoEmail, string contatoTelefoneComercial, string contatoTelefoneResidencial, string contatoObservacao)
        {
            ContatoCelular = contatoCelular;
            ContatoEmail = contatoEmail;
            ContatoTelefoneComercial = contatoTelefoneComercial;
            ContatoTelefoneResidencial = contatoTelefoneResidencial;
            ContatoObservacao = contatoObservacao;
        }

        private void ValidateContatoNotEmpty()
        {
            RuleFor(c => this)
                .Must(c => ValidateContatoProperties())
                .WithMessage("Você deve preencher pelo menos um dos meios de contato.");
        }

        private void ValidateContatoEmail()
        {
            RuleFor(c => ContatoEmail)
                .EmailAddress()
                .MaximumLength(100)
                .WithMessage("O e-mail do cliente deve ter entre 10 e 100 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneResidencial()
        {
            RuleFor(c => ContatoTelefoneResidencial)
                .MaximumLength(15)
                .WithMessage("O telefone residencial do cliente deve ter entre 8 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoTelefoneComercial()
        {
            RuleFor(c => ContatoTelefoneComercial)
                .MaximumLength(15)
                .WithMessage("O telefone comercial do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoCelular()
        {
            RuleFor(c => ContatoCelular)
                .MaximumLength(15)
                .WithMessage("O celular do cliente deve ter entre 10 e 15 caracteres e não deve estar vazio.");
        }

        private void ValidateContatoObservacao()
        {
            RuleFor(c => ContatoObservacao)
                .MaximumLength(250)
                .WithMessage("A observação deve ter até 250 caracteres e não deve estar vazia.");
        }
        
        private bool ValidateContatoProperties()
        {
            if (!string.IsNullOrWhiteSpace(ContatoCelular))
                return true;
            if (!string.IsNullOrWhiteSpace(ContatoTelefoneComercial))
                return true;
            if (!string.IsNullOrWhiteSpace(ContatoTelefoneResidencial))
                return true;
            if (!string.IsNullOrWhiteSpace(ContatoEmail))
                return true;

            return false;
        }
    }
}
