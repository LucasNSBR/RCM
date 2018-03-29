using RCM.Domain.Core.Models;
using RCM.Domain.Models.CidadeModels;
using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Domain.Models
{
    public class Endereco : Entity
    {
        public int Numero { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set;  }
        public Guid CidadeId { get; private set; }
        public virtual Cidade Cidade { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        protected Endereco() { }

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