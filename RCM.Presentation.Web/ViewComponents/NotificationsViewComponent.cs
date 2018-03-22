using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;

namespace RCM.Presentation.Web.ViewComponents
{
    public class NotificationsViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public NotificationsViewComponent(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _domainNotificationHandler.GetNotifications();
            return View(notifications); 
        }
    }
}
