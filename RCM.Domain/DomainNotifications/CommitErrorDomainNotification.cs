using RCM.Domain.Core.Notifications;

namespace RCM.Domain.DomainNotifications
{
    public class CommitErrorDomainNotification : DomainNotification
    {
        public CommitErrorDomainNotification()
        {
        }

        public CommitErrorDomainNotification(string body)
        {
            Title = "Nós temos um erro de commit.";
            Body = body;
        }

        public CommitErrorDomainNotification(string title, string body) : base(title, body)
        {
        }
    }
}
