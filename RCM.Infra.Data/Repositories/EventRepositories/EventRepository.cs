using RCM.Domain.Core.Events;
using RCM.Domain.Repositories.EventRepositories;
using RCM.Infra.Data.Context;
using System;

namespace RCM.Infra.Data.Repositories.EventRepositories
{
    public class EventRepository : IEventRepository
    {
        private readonly RCMEventDbContext _dbContext;

        public EventRepository(RCMEventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Guid id, Guid aggregateId, DateTime dateCreated, string type, string data)
        {
            NormalizedEvent @event = new NormalizedEvent(id, aggregateId, dateCreated, type, data);
            _dbContext.Add(@event);
            _dbContext.SaveChanges();
        }
    }
}
