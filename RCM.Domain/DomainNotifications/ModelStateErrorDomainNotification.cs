using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class ModelStateErrorDomainNotification : DomainNotification
    {
        public ModelStateErrorDomainNotification()
        {
        }

        public ModelStateErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
