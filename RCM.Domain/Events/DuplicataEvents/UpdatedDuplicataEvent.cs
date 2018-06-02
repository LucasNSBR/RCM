using RCM.Domain.Models.DuplicataModels;

namespace RCM.Domain.Events.DuplicataEvents
{
    public class UpdatedDuplicataEvent : DuplicataEvent
    {
        public UpdatedDuplicataEvent(Duplicata duplicata) : base(duplicata)
        {
        }
    }
}
