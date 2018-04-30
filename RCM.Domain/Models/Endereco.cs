using RCM.Domain.Core.Models;

namespace RCM.Domain.Models
{
    public class Endereco : ValueObject
    {
        public int Numero { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set;  }
        
        protected Endereco() { }

        public Endereco(int numero, string rua, string bairro, string complemento = null, string cep = null)
        {
            Numero = numero;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            CEP = cep;
        }
    }
}