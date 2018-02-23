using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class PropertyErrorDomainNotification : DomainNotification
    {
        public PropertyErrorDomainNotification()
        {
        }

        public PropertyErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
