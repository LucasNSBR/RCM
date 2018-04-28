using RCM.Domain.Core.Models;
using System;

namespace RCM.Domain.Models.EmpresaModels
{
    public class Empresa : Entity<Empresa>
    {
        public byte[] Logo { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Descricao { get; private set; }
        public string CNPJ { get; private set; }
        public string InscricaoEstadual { get; private set; }

        protected Empresa() { }

        public Empresa(string nomeFantasia, string razaoSocial, string cnpj, string inscricaoEstadual)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
        }

        public Empresa(Guid id, string nomeFantasia, string razaoSocial, string cnpj, string inscricaoEstadual)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
        }
    }
}
