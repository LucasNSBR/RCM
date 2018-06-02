using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Events.BancoEvents
{
    public class AddedBancoEvent : BancoEvent
    {
        public AddedBancoEvent(Banco banco) : base(banco)
        {
        }
    }
}
