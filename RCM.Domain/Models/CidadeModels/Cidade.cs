using RCM.Domain.Core.Models;
using RCM.Domain.Models.EstadoModels;
using System;

namespace RCM.Domain.Models.CidadeModels
{
    public class Cidade : Entity
    {
        public string Nome { get; private set; }
        public Guid EstadoId { get; private set; }
        public virtual Estado Estado { get; private set; }

        private Cidade() { }

        public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
        }
    }
}