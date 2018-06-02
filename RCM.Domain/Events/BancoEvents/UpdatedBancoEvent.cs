using RCM.Domain.Models.BancoModels;

namespace RCM.Domain.Events.BancoEvents
{
    public class UpdatedBancoEvent : BancoEvent
    {
        public UpdatedBancoEvent(Banco banco) : base(banco)
        {
        }
    }
}
