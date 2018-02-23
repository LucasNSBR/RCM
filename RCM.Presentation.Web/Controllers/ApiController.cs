using Microsoft.AspNetCore.Mvc;
using RCM.Domain.DomainNotificationHandlers;
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
            NotifyPropertyErrors();

            if (!ModelState.IsValid || !_domainNotificationHandler.IsEmpty())
                return BadRequest(new
                {
                    data = ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage)
                });

            return Ok(new { data = result });
        }

        protected void NotifyPropertyErrors()
        {
            if (!_domainNotificationHandler.IsEmpty())
                _domainNotificationHandler.GetNotifications()
                    .ToList()
                    .ForEach(n => ModelState.AddModelError(n.Title, n.Body));
        }
    }
}