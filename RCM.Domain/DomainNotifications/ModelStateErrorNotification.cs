using RCM.Domain.Core.Notifications;
using RCM.Domain.Helpers;

namespace RCM.Domain.DomainNotifications
{
    public class ModelStateErrorNotification : DomainNotification
    {
        public ModelStateErrorNotification(string body) : base(NotificationMessageContants.ModelStateError, body)
        {
        }

        public ModelStateErrorNotification(string title, string body) : base(title, body)
        {
        }
    }
}
