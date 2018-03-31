using RCM.Domain.Core.Models;
using RCM.Domain.Models.ChequeModels;
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

        public Banco(string nome)
        {
            Nome = nome;

            _cheques = new List<Cheque>();
        }
    }
}