using System;

namespace RCM.Domain.Core.Events
{
    public class NormalizedEvent 
    {
        public Guid Id { get; private set; }
        public Guid AggregateId { get; private set; }

        public string Type { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string Data { get; private set; }

        public NormalizedEvent(Guid id, Guid aggregateId, DateTime dateCreated, string type, string data)
        {
            Id = id;
            AggregateId = aggregateId;
            DateCreated = dateCreated;
            Type = type;
            Data = data;
        }
    }
}
