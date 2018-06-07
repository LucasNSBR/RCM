using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Events.BancoEvents
{
    public class RemovedBancoEvent : BancoEvent
    {
        public RemovedBancoEvent(Banco banco) : base(banco)
        {
        }

        public override void Normalize()
        {
            Args.Add(nameof(Banco.Id), Banco.Id);
        }
    }
}
