using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class AuthenticationErrorNotification : DomainNotification
    {
        public AuthenticationErrorNotification(string body) : base(NotificationMessageConstants.AuthenticationError, body, DomainNotificationType.Error)
        {
        }

        public AuthenticationErrorNotification(string title, string body) : base(title, body, DomainNotificationType.Error)
        {
        }
    }
}
