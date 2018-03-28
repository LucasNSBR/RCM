using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCM.Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        private List<INotification> _events;

        [NotMapped]
        public IReadOnlyList<INotification> Events
        {
            get
            {
                return _events;
            }
        }

        public Entity()
        {
            Id = Guid.NewGuid();

            _events = new List<INotification>();
        }

        public void AddDomainEvent(INotification notification)
        {
            _events.Add(notification);
        }
    }
}
