using RCM.Domain.Core.Models;
using RCM.Domain.Models.CidadeModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.EstadoModels
{
    public class Estado : Entity
    {
        public string Nome { get; private set; }

        private List<Cidade> _cidades;
        public virtual IReadOnlyList<Cidade> Cidades
        {
            get
            {
                return _cidades;
            }
        }

        protected Estado() { }

        public Estado(string nome)
        {
            Nome = nome;

            _cidades = new List<Cidade>();
        }
    }
}