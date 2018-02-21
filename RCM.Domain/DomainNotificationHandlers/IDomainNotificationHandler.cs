using RCM.Domain.Core.Notification;
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
