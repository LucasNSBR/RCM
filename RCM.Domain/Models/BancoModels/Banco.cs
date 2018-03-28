using RCM.Domain.Models.ChequeModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.BancoModels
{
    public class Banco
    {
        public int Id { get; private set; }
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

        private Banco() { }

        public Banco(string nome)
        {
            Nome = nome;

            _cheques = new List<Cheque>();
        }
    }
}