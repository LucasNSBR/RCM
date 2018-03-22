using RCM.Domain.Core.Notifications;
using System;
using System.Collections.Generic;

namespace RCM.Domain.DomainNotificationHandlers
{
    public class DomainNotificationHandler : IDomainNotificationHandler, IDisposable
    {
        private ICollection<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void AddNotification(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool IsEmpty()
        {
            return _notifications.Count == 0;
        }

        public void Dispose()
        {
            _notifications.Clear();
        }
    }
}
