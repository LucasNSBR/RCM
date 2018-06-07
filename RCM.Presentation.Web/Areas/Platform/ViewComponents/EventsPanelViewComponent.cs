using Microsoft.AspNetCore.Mvc;
using RCM.Application.EventServices;
using System;

namespace RCM.Presentation.Web.Areas.Platform.ViewComponents
{
    public class EventsPanelViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public EventsPanelViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IViewComponentResult Invoke(Guid aggregateId)
        {
            var list = _eventService.GetByAggregate(aggregateId);
            return View(list);
        }
    }
}
