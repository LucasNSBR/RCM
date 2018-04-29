using RCM.Domain.Core.Models;
using RCM.Domain.Models.ChequeModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.ClienteModels
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual Contato Contato { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        private List<Cheque> _cheques;
        public virtual IReadOnlyList<Cheque> Cheques
        {
            get
            {
                return _cheques;
            }
        }

        protected Cliente() { }

        public Cliente(Guid id, string nome, Contato contato, string descricao = null)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            
            _cheques = new List<Cheque>();
            Contato = contato;
        }

        public Cliente(string nome, Contato contato, string descricao = null)
        {
            Nome = nome;
            Descricao = descricao;
            
            _cheques = new List<Cheque>();
            Contato = contato;
        }
    }
}