using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class CommandValidationErrorNotification : DomainNotification
    {
        public CommandValidationErrorNotification()
        {
        }

        public CommandValidationErrorNotification(string title, string body) : base(title, body)
        {
        }
    }
}
