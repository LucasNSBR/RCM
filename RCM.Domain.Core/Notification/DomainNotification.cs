using RCM.Domain.Core.Models;
using System;

namespace RCM.Domain.Core.Notification
{
    public abstract class DomainNotification : Message
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? DateRead { get; private set; }

        public DomainNotification()
        {
        }

        public DomainNotification(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public void MarkAsRead()
        {
            DateRead = DateTime.Now;
        }
    }
}
