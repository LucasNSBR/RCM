using RCM.Domain.Core.Models;
using RCM.Domain.Models.ChequeModels;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Models.BancoModels
{
    public class Banco : Entity<Banco>
    {
        public int CodigoCompensacao { get; private set; }
        public string Nome { get; private set; }

        private List<Cheque> _cheques;
        public virtual IReadOnlyList<Cheque> Cheques
        {
            get
            {
                return _cheques;   
            }
        }


        protected Banco() { }

        public Banco(Guid id, string nome, int codigoCompensacao)
        {
            Id = id;
            Nome = nome;
            CodigoCompensacao = codigoCompensacao;

            _cheques = new List<Cheque>();
        }

        public Banco(string nome, int codigoCompensacao)
        {
            Nome = nome;
            CodigoCompensacao = codigoCompensacao;

            _cheques = new List<Cheque>();
        }
    }
}