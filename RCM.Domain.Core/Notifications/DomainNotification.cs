using RCM.Domain.Core.Models;

namespace RCM.Domain.Core.Notifications
{
    public abstract class DomainNotification : Message
    {
        public string Title { get; private set; }
        public string Body { get; private set; }

        public DomainNotificationType Type { get; private set; }
        

        public DomainNotification(string body)
        {
            Body = body;
        }

        public DomainNotification(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public DomainNotification(string title, string body, DomainNotificationType type)
        {
            Title = title;
            Body = body;
            Type = type;
        }
    }
}
