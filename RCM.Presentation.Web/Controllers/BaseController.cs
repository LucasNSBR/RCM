using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Presentation.Web.Areas.Platform.Controllers;
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

        protected void NotifyModelStateErrors()
        {
            foreach (var error in ModelState.Values.SelectMany(e => e.Errors))
            {
                _domainNotificationHandler.AddNotification(new ModelStateErrorDomainNotification(error.ErrorMessage));
            }
        }

        public RedirectToActionResult RedirectToPlatform()
        {
            return RedirectToAction(nameof(DuplicatasController.Index), "Clientes", new { area = "Platform" });
        }
    }
}