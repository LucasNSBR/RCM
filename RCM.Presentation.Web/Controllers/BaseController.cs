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

        protected void NotifyCommandResultErrors(IReadOnlyList<CommandError> errors)
        {
            foreach (var error in errors)
            {
               _domainNotificationHandler.AddNotification(new CommandErrorNotification(error.Code, error.Description));
            }

            TempData["Notifications"] = JsonConvert.SerializeObject(_domainNotificationHandler.GetNotifications());
        }

        protected void NotifyCommandResultSuccess(string message = null)
        {
            _domainNotificationHandler.AddNotification(new CommandSuccessNotification(message ?? "Comando executado com sucesso."));
            TempData["Notifications"] = JsonConvert.SerializeObject(_domainNotificationHandler.GetNotifications());
        }

        public RedirectToActionResult RedirectToPlatform()
        {
            return RedirectToAction(nameof(DuplicatasController.Index), "Clientes", new { area = "Platform" });
        }
    }
}