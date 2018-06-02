using RCM.Domain.Models.DuplicataModels;

namespace RCM.Domain.Events.DuplicataEvents
{
    public class AddedDuplicataEvent : DuplicataEvent
    {
        public AddedDuplicataEvent(Duplicata duplicata) : base(duplicata)
        {
        }
    }
}
