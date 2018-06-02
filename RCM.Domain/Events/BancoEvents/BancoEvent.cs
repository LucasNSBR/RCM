using RCM.Domain.Core.Events;
using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Events.BancoEvents
{
    public abstract class BancoEvent : DomainEvent
    {
        public Banco Banco { get; set; }

        public BancoEvent(Banco banco)
        {
            Banco = banco;
        }

        public override void Normalize()
        {
            AggregateId = Banco.Id;

            Args.Add(nameof(Banco.CodigoCompensacao), Banco.CodigoCompensacao);
            Args.Add(nameof(Banco.Nome), Banco.Nome);
        }
    }
}
