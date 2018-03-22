using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class CommitErrorDomainNotification : DomainNotification
    {
        public CommitErrorDomainNotification(string body) : base(NotificationMessageContants.CommitError, body)
        {
        }

        public CommitErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
