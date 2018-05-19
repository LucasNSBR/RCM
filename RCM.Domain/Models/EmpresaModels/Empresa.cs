using RCM.Domain.Core.Models;
using RCM.Domain.Models.ValueObjects;
using System;

namespace RCM.Domain.Models.EmpresaModels
{
    public class Empresa : Entity<Empresa>
    {
        public byte[] Logo { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Descricao { get; private set; }

        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }
        public Documento Documento { get; private set; }

        protected Empresa() { }

        public Empresa(string nomeFantasia, string razaoSocial, string descricao, Documento documento, Contato contato, Endereco endereco)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Descricao = descricao;
            Documento = documento;
            Contato = contato;
            Endereco = endereco;
        }

        public Empresa(Guid id, string nomeFantasia, string razaoSocial, string descricao, Documento documento, Contato contato, Endereco endereco)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Descricao = descricao;
            Documento = documento;
            Contato = contato;
            Endereco = endereco;
        }
    }
}
