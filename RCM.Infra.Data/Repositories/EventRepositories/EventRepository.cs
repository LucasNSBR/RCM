using Newtonsoft.Json;
using RCM.Domain.Core.Events;
using RCM.Domain.Repositories.EventRepositories;
using RCM.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RCM.Infra.Data.Repositories.EventRepositories
{
    public class EventRepository : IEventRepository
    {
        private readonly RCMEventDbContext _dbContext;

        public EventRepository(RCMEventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<NormalizedEvent> GetByAggregate(Guid aggregateId)
        {
            return _dbContext
                .DomainEvents
                .Where(ne => ne.AggregateId == aggregateId)
                .OrderByDescending(ne => ne.DateCreated);
        }

        public void Save(Guid id, Guid aggregateId, DateTime dateCreated, string type, Dictionary<string, object> args)
        {
            string data = JsonConvert.SerializeObject(args);

            NormalizedEvent @event = new NormalizedEvent(id, aggregateId, dateCreated, type, data);
            _dbContext.Add(@event);
            _dbContext.SaveChanges();
        }
    }
}
