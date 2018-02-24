using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using System;
using System.Linq;

namespace RCM.Presentation.Web.Controllers
{
    public abstract class ApiController : Controller
    {
        protected readonly IDomainNotificationHandler _domainNotificationHandler;

        public ApiController(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected new IActionResult Response(object result = null)
        {
            NotifyModelStateErrors();

            if (!_domainNotificationHandler.IsEmpty())
                return BadRequest(new
                {
                    errors = _domainNotificationHandler.GetNotifications()
                    .ToList().Select(e => e.Body)
                });

            return Ok(result);
        }

        protected void AddModelErrorNotification(string value = null, string key = null, Exception exception = null)
        {
            _domainNotificationHandler.AddNotification(new PropertyErrorDomainNotification(key, value));
        }

        protected void NotifyModelStateErrors()
        {
            foreach (var error in ModelState.Values.SelectMany(e => e.Errors))
            {
                AddModelErrorNotification("error", error.ErrorMessage);
            }
        }
    }
}