using RCM.Domain.Core.Models;

namespace RCM.Domain.Models.ValueObjects
{
    public class Documento : ValueObject
    {
        public string CadastroNacional { get; private set; } //CPF ou CNPJ
        public string CadastroEstadual { get; private set; } //Inscrição Estadual ou RG


        protected Documento() { }
        
        public Documento(string cadastroNacional, string cadastroEstadual)
        {
            CadastroNacional = cadastroNacional;
            CadastroEstadual = cadastroEstadual;
        }
    }
}
