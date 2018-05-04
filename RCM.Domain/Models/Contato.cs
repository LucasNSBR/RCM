using RCM.Domain.Core.Models;

namespace RCM.Domain.Models
{
    public class Contato : ValueObject
    {
        public string Celular { get; private set; }
        public string Email { get; private set; }
        public string TelefoneResidencial { get; private set; }
        public string TelefoneComercial { get; private set; }
        public string Observacao { get; private set; }

        protected Contato() { }

        public Contato(string celular = null, string email = null, string telefoneComercial = null, string telefoneResidencial = null, string observacao = null)
        {
            Celular = celular;
            Email = email;
            TelefoneComercial = telefoneComercial;
            TelefoneResidencial = telefoneResidencial;
            Observacao = observacao;
        }
    }
}