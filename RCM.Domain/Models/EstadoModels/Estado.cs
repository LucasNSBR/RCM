using RCM.Domain.Core.Models;
using RCM.Domain.Models.CidadeModels;
using System.Collections.Generic;

namespace RCM.Domain.Models.EstadoModels
{
    public class Estado : Entity<Estado>
    {
        public string Sigla { get; private set; }
        public string Nome { get; private set; }

        private List<Cidade> _cidades;
        public IReadOnlyList<Cidade> Cidades
        {
            get
            {
                return _cidades;
            }
        }

        protected Estado() { }

        public Estado(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;

            _cidades = new List<Cidade>();
        }
    }
}