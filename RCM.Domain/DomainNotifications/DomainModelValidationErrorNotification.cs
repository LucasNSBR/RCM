using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class DomainModelValidationErrorNotification : DomainNotification
    {
        public DomainModelValidationErrorNotification(string title, string body) : base(title, body)
        {
        }
    }
}
