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

        public virtual Contato Contato { get; set; }

        private List<Endereco> _enderecos;
        public virtual IReadOnlyList<Endereco> Enderecos
        {
            get
            {
                return _enderecos;
            }
        }

        private List<Cheque> _cheques;
        public virtual IReadOnlyList<Cheque> Cheques
        {
            get
            {
                return _cheques;
            }
        }

        protected Cliente() { }

        public Cliente(Guid id, string nome, string descricao = null)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
 
            _enderecos = new List<Endereco>();
            _cheques = new List<Cheque>();
        }

        public Cliente(string nome, string descricao = null)
        {
            Nome = nome;
            Descricao = descricao;

            _enderecos = new List<Endereco>();
            _cheques = new List<Cheque>();
        }

        public void AdicionarContato(Contato contato)
        {
            Contato = contato;
        }

        public void RemoverContato()
        {
            Contato = null;
        }
    }
}