using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class CommandValidationErrorDomainNotification : DomainNotification
    {
        public CommandValidationErrorDomainNotification()
        {
        }

        public CommandValidationErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
