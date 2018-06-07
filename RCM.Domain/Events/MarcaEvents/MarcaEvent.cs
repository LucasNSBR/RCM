using RCM.Domain.Core.Events;
using RCM.Domain.Models.MarcaModels;

namespace RCM.Domain.Events.MarcaEvents
{
    public abstract class MarcaEvent : DomainEvent
    {
        public Marca Marca { get; private set; }

        public MarcaEvent(Marca marca)
        {
            Marca = marca;
            AggregateId = Marca.Id;
        }

        public override void Normalize()
        {
            Args.Add(nameof(Marca.Nome), Marca.Nome);
            Args.Add(nameof(Marca.Observacao), Marca.Observacao);
        }
    }
}
