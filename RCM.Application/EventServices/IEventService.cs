using RCM.Application.ViewModels.EventViewModels;
using System;
using System.Collections.Generic;

namespace RCM.Application.EventServices
{
    public interface IEventService
    {
        IEnumerable<NormalizedEventViewModel> GetByAggregate(Guid aggregateId);
    }
}
