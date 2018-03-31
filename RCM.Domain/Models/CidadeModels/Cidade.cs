using RCM.Domain.Core.Models;
using RCM.Domain.Models.EstadoModels;
using System;

namespace RCM.Domain.Models.CidadeModels
{
    public class Cidade : Entity<Cidade>
    {
        public string Nome { get; private set; }
        public Guid EstadoId { get; private set; }
        public virtual Estado Estado { get; private set; }

        protected Cidade() { }

        public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
        }
    }
}