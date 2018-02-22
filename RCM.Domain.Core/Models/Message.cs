using MediatR;
using System;

namespace RCM.Domain.Core.Models
{
    public abstract class Message : INotification
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }

        public Message()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}
