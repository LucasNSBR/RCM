using RCM.Domain.Core.Models;
using RCM.Domain.Models.CidadeModels;
using System;

namespace RCM.Domain.Models.ValueObjects
{
    public class Endereco : ValueObject
    {
        public string Rua { get; private set; }
        public int? Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set; }

        public Guid CidadeId { get; private set; }
        public Cidade Cidade { get; private set; }


        protected Endereco() { }

        public Endereco(string rua, int? numero, string bairro, string complemento, Cidade cidade, string cep)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            CEP = cep;
        }
    }
}