﻿using RCM.Domain.Core.Models;
using RCM.Domain.Models.ClienteModels;
using System;

namespace RCM.Domain.Models
{
    public class Contato : Entity
    {
        public string Nome { get; private set; }
        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public string Observacao { get; private set; }

        private Contato() { }

        public Contato(string nome, Cliente cliente)
        {
            Nome = nome;
            Cliente = cliente;
        }
    }
}