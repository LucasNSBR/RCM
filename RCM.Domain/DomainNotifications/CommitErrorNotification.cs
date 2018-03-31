using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommitErrorNotification : DomainNotification
    {
        public CommitErrorNotification(string body) : base(NotificationMessageContants.CommitError, body)
        {
        }

        public CommitErrorNotification(string title, string body) : base(title, body)
        {
        }
    }
}
