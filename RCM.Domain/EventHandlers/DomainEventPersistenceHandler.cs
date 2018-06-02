using MediatR;
using Newtonsoft.Json;
using RCM.Domain.Core.Events;
using RCM.Domain.Repositories.EventRepositories;
using System.Threading;
using System.Threading.Tasks;

namespace RCM.Domain.EventHandlers
{
    public sealed class DomainEventPersistenceHandler : INotificationHandler<DomainEvent>
    {
        private readonly IEventRepository _eventRepository;

        public DomainEventPersistenceHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task Handle(DomainEvent @event, CancellationToken cancellationToken)
        {
            @event.Normalize();

            var data = JsonConvert.SerializeObject(@event.Args);
            var dateCreated = @event.DateCreated;
            var id = @event.Id;
            var aggregateId = @event.AggregateId;
            var type = @event.Type;

            _eventRepository.Save(id, aggregateId, dateCreated, type, data);

            return Task.CompletedTask;
        }
    }
}
