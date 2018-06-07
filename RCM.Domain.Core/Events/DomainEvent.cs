using RCM.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace RCM.Domain.Core.Events
{
    public abstract class DomainEvent : Message
    {
        public Guid Id { get; private set; }
        public Guid AggregateId { get; protected set; }

        public string Type { get; protected set; }

        public Dictionary<string, object> Args { get; private set; }


        public DomainEvent()
        {
            Id = Guid.NewGuid();
            Type = GetType().Name;
            Args = new Dictionary<string, object>();
        }

        public abstract void Normalize();
    }
}
