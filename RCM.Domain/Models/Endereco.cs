using RCM.Domain.Core.Models;
using RCM.Domain.Models.CidadeModels;
using System;

namespace RCM.Domain.Models
{
    public class Endereco : ValueObject
    {
        public int Numero { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set; }
        public Guid CidadeId { get; private set; }
        public Cidade Cidade { get; private set; }

        protected Endereco() { }

        public Endereco(int numero, string rua, string bairro, string complemento, Cidade cidade, string cep)
        {
            Numero = numero;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            CEP = cep;
        }
    }
}