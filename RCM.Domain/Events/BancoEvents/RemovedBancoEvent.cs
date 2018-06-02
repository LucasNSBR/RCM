using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Events.BancoEvents
{
    public class RemovedBancoEvent : BancoEvent
    {
        public RemovedBancoEvent(Banco banco) : base(banco)
        {
        }
    }
}
