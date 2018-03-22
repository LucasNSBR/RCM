using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommandValidationErrorDomainNotification : DomainNotification
    {
        public CommandValidationErrorDomainNotification(string body) : base(NotificationMessageContants.CommandValidationError, body)
        {
        }

        public CommandValidationErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
