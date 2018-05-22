using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RCM.Domain.Core.Errors;
using RCM.Domain.DomainNotificationHandlers;
using RCM.Domain.DomainNotifications;
using RCM.Presentation.Web.Areas.Platform.Controllers;
using System.Collections.Generic;
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

        protected void NotifyModelStateErrors()
        {
            foreach (var error in ModelState.Values.SelectMany(e => e.Errors))
            {
                _domainNotificationHandler.AddNotification(new ModelErrorNotification(error.ErrorMessage));
            }
        }

        protected void NotifyCommandResultErrors(IReadOnlyList<Error> errors)
        {
            foreach (var error in errors)
            {
               _domainNotificationHandler.AddNotification(new CommandErrorNotification(error.Code, error.Description));
            }
        }

        public void NotifyIdentityError(string description)
        {
            _domainNotificationHandler.AddNotification(new AuthenticationErrorNotification(description));
        }

        public void NotifyError(string description)
        {
            _domainNotificationHandler.AddNotification(new CommandErrorNotification(description));
        }

        public void NotifyIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                _domainNotificationHandler.AddNotification(new AuthenticationErrorNotification(error.Description));
            }
        }

        protected void NotifyCommandResultSuccess(string message = null)
        {
            //Will be deserialized on NotificationBarViewComponent
            //Can't be added directly to DomainNotificationHandler because the action redirect lose the notifications data
            var notificationJson = JsonConvert.SerializeObject(new CommandSuccessNotification(message ?? "Comando executado com sucesso."));
            TempData["SuccessNotification"] = notificationJson;
        }

        public RedirectToActionResult RedirectToPlatform()
        {
            return RedirectToAction(nameof(DuplicatasController.Index), "Clientes", new { area = "Platform" });
        }
    }
}