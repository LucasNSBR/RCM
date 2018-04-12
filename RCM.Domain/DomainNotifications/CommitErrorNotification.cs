using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommitErrorNotification : DomainNotification
    {
        public CommitErrorNotification(string body) : base(NotificationMessageConstants.CommitError, body, DomainNotificationType.Error)
        {
        }

        public CommitErrorNotification(string title, string body) : base(title, body, DomainNotificationType.Success)
        {
        }
    }
}
