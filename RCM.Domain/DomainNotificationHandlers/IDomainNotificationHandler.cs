using RCM.Domain.Core.Notifications;
using System.Collections.Generic;

namespace RCM.Domain.DomainNotificationHandlers
{
    public interface IDomainNotificationHandler
    {
        bool IsEmpty();
        void AddNotification(DomainNotification notification);
        IEnumerable<DomainNotification> GetNotifications();
    }
}
