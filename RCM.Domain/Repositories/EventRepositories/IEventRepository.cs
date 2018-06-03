using RCM.Domain.Core.Events;
using System;
using System.Linq;

namespace RCM.Domain.Repositories.EventRepositories
{
    public interface IEventRepository
    {
        IQueryable<NormalizedEvent> GetByAggregate(Guid aggregateId);
        void Save(Guid id, Guid aggregateId, DateTime dateCreated, string type, string data);
    }
}
