using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommandSuccessNotification : DomainNotification
    {
        public CommandSuccessNotification(string body) : base(NotificationMessageConstants.CommandSuccess, body, DomainNotificationType.Success)
        {
        }

        public CommandSuccessNotification(string title, string body) : base(title, body, DomainNotificationType.Success)
        {
        }
    }
}
