using MediatR;
using System;

namespace RCM.Domain.Core.Models
{
    public abstract class Message : INotification
    {
        public DateTime DateCreated { get; private set; }

        public Message()
        {
            DateCreated = DateTime.Now;
        }
    }
}
