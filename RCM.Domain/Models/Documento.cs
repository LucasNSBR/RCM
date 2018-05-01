using RCM.Domain.Core.Models;

namespace RCM.Domain.Models
{
    public class Documento : ValueObject
    {
        //CPF ou CNPJ
        public string CadastroNacional { get; private set; }
        //Inscrição Estadual ou RG
        public string CadastroEstadual { get; private set; }

        public Documento() { }

        public Documento(string cadastroNacional, string cadastroEstadual)
        {
            CadastroNacional = cadastroNacional;
            CadastroEstadual = cadastroEstadual;
        }
    }
}
