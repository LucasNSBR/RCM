using MediatR;
using System.Collections.Generic;

namespace RCM.Domain.Core.Models
{
    public interface IEntity
    {
        IList<INotification> GetEvents();
        void AddDomainEvent(INotification notification);
    }
}
