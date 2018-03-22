using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class AuthenticationErrorDomainNotification : DomainNotification
    {
        public AuthenticationErrorDomainNotification(string body) : base(NotificationMessageContants.AuthenticationError, body)
        {
        }

        public AuthenticationErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
