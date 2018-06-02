using RCM.Domain.Core.Events;
using RCM.Domain.Models.ClienteModels;

namespace RCM.Domain.Events.ClienteEvents
{
    public abstract class ClienteEvent : DomainEvent
    {
        public Cliente Cliente { get; set; }
        
        public ClienteEvent(Cliente cliente)
        {
            Cliente = cliente;
        }

        public override void Normalize()
        {
            AggregateId = Cliente.Id;

            Args.Add(nameof(Cliente.Nome), Cliente.Nome);
            Args.Add(nameof(Cliente.Tipo), Cliente.Tipo);
            Args.Add(nameof(Cliente.Pontuacao), Cliente.Pontuacao);
            Args.Add(nameof(Cliente.Descricao), Cliente.Descricao);
        }
    }
}
