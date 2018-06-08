using RCM.Domain.Core.Models;
using RCM.Domain.Models.VendaModels;
using System;

namespace RCM.Domain.Models.ServicoModels
{
    public class Servico : Entity<Servico>
    {
        public Guid VendaId { get; private set; }
        public Venda Venda { get; private set; }
        public string Detalhes { get; private set; }

        public decimal PrecoServico { get; private set; }


        protected Servico() { }

        public Servico(Venda venda, string detalhes, decimal precoServico)
        {
            Venda = venda;
            Detalhes = detalhes;
            PrecoServico = precoServico;
        }

        public Servico(Guid id, Venda venda, string detalhes, decimal precoServico)
        {
            Id = id;
            Venda = venda;
            Detalhes = detalhes;
            PrecoServico = precoServico;
        }
    }
}
