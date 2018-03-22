using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class ModelStateErrorDomainNotification : DomainNotification
    {
        public ModelStateErrorDomainNotification(string body) : base(NotificationMessageContants.ModelStateError, body)
        {
        }

        public ModelStateErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
