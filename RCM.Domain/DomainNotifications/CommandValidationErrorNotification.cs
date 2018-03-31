using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommandValidationErrorNotification : DomainNotification
    {
        public CommandValidationErrorNotification(string body) : base(NotificationMessageContants.CommandValidationError, body)
        {
        }

        public CommandValidationErrorNotification(string title, string body) : base(title, body)
        {
        }
    }
}
