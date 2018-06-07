using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Presentation.Web.Converters;
using System.Collections.Generic;

namespace RCM.Presentation.Web.ViewComponents
{
    public class NotificationsBarViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public NotificationsBarViewComponent(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        public IViewComponentResult Invoke()
        {
            var notificationJson = TempData["SuccessNotification"];

            if (notificationJson != null)
            {
                var successNotification = JsonConvert.DeserializeObject<CommandSuccessNotification>(notificationJson.ToString(), new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter>
                    {
                        new SuccessNotificationJsonConverter()
                    }
                });

                if (successNotification != null)
                {
                    _domainNotificationHandler.AddNotification(successNotification);
                }
            }

            var notifications = _domainNotificationHandler.GetNotifications();
            return View(notifications);
        }
    }
}
