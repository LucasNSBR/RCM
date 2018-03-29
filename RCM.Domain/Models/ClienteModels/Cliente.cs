using RCM.Domain.Core.Models;
using RCM.Domain.Models.ChequeModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.ClienteModels
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        private List<Contato> _contatos;
        public virtual IReadOnlyList<Contato> Contatos
        {
            get
            {
                return _contatos;
            }
        }

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

        public Cliente(string nome)
        {
            _contatos = new List<Contato>();
            _enderecos = new List<Endereco>();
            _cheques = new List<Cheque>();

            Nome = nome;
        }
    }
}