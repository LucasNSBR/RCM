using AutoMapper;
using AutoMapper.QueryableExtensions;
using RCM.Application.ViewModels.EventViewModels;
using RCM.Domain.Repositories.EventRepositories;
using System;
using System.Collections.Generic;

namespace RCM.Application.EventServices
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public IEnumerable<NormalizedEventViewModel> GetByAggregate(Guid aggregateId)
        {
            var list = _eventRepository.GetByAggregate(aggregateId);
            return list.ProjectTo<NormalizedEventViewModel>();
        }
    }
}
