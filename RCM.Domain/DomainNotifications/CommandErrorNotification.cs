using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommandErrorNotification : DomainNotification
    {
        public CommandErrorNotification(string body) : base(NotificationMessageConstants.CommandValidationError, body, DomainNotificationType.Error)
        {
        }

        public CommandErrorNotification(string title, string body) : base(title, body, DomainNotificationType.Error)
        {
        }
    }
}
