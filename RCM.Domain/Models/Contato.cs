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

        public Contato() { }

        public Contato(string celular, string email = null, string telefoneComercial = null, string telefoneResidencial = null, string observacao = null)
        {
            Email = email;
            TelefoneComercial = telefoneComercial;
            TelefoneResidencial = telefoneResidencial;
            Celular = celular;
            Observacao = observacao;
        }
    }
}