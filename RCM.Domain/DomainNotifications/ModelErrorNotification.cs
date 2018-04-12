using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class ModelErrorNotification : DomainNotification
    {
        public ModelErrorNotification(string body) : base(NotificationMessageConstants.ModelStateError, body, DomainNotificationType.Error)
        {
        }

        public ModelErrorNotification(string title, string body) : base(title, body, DomainNotificationType.Error)
        {
        }
    }
}
