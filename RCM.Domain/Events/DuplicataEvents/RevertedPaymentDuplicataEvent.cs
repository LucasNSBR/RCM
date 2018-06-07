using RCM.Domain.Models.DuplicataModels;
using System;

namespace RCM.Domain.Events.DuplicataEvents
{
    public class RevertedPaymentDuplicataEvent : DuplicataEvent
    {
        public RevertedPaymentDuplicataEvent(Duplicata duplicata) : base(duplicata)
        {
        }

        public override void Normalize()
        {
            Args.Add("Data do Estorno", DateTime.Now);
        }
    }
}
