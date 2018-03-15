using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class AuthenticationErrorDomainNotification : DomainNotification
    {
        public AuthenticationErrorDomainNotification()
        {
        }

        public AuthenticationErrorDomainNotification(string body) : base("AUTHENTICATION ERROR", body)
        {
        }

        public AuthenticationErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
