using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using System;
using System.Linq;

namespace RCM.Presentation.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IDomainNotificationHandler _domainNotificationHandler;

        public BaseController(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected bool Success()
        {
            return _domainNotificationHandler.IsEmpty();
        }

        private void AddModelErrorNotification(string key = null, string value = null, Exception exception = null)
        {
            _domainNotificationHandler.AddNotification(new ModelStateErrorDomainNotification(key, value));
        }

        protected void NotifyModelStateErrors()
        {
            foreach (var error in ModelState.Values.SelectMany(e => e.Errors))
            {
                AddModelErrorNotification("MODEL STATE ERROR {0}", error.ErrorMessage);
            }
        }
    }
}