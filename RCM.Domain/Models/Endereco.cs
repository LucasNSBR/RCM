using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Models
{
    public class Endereco
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set;  }
        public int CidadeId { get; private set; }
        public virtual Cidade Cidade { get; private set; }
        public int ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        private Endereco() { }

        public Endereco(int numero, string rua, string bairro, Cidade cidade, Cliente cliente)
        {
            Numero = numero;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Cliente = cliente;
        }
    }
}